using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using System.Linq;
using System.Threading;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductForClientRepository 
        : BaseRepository<DAL.App.DTO.ProductForClient, Domain.ProductForClient,
            AppDbContext>, IProductForClientRepository
    {
        public ProductForClientRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new ProductForClientMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.ProductForClient>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Product)
                .ThenInclude(p => p.ProductName)
                .ThenInclude(t => t.Translations)
                .Include(p => p.Client)
                .Select(e => ProductForClientMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<List<DAL.App.DTO.ProductForClient>> AllForClientAsync(int? clientId)
        {
            return await RepositoryDbSet
                .Include(p => p.Product)
                .ThenInclude(p => p.ProductName)
                .ThenInclude(t => t.Translations)
//                .Include(p => p.ProductServices)
//                .ThenInclude(p => p.WorkObject)
                .Include(p => p.Client)
                .Where(p => p.ClientId == clientId)
                .Select(e => ProductForClientMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public override async Task<DAL.App.DTO.ProductForClient> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var productForClient = await RepositoryDbSet.FindAsync(id);

            if (productForClient != null)
            {
                await RepositoryDbContext.Entry(productForClient)
                    .Reference(c => c.Client)
                    .LoadAsync();
                await RepositoryDbContext.Entry(productForClient)
                    .Reference(c => c.Product)
                    .LoadAsync();
                await RepositoryDbContext.Entry(productForClient.Product)
                    .Reference(c => c.ProductName)
                    .LoadAsync();
                await RepositoryDbContext.Entry(productForClient.Product.ProductName)
                    .Collection(c => c.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                
                await RepositoryDbContext.Entry(productForClient)
                    .Collection(c => c.ProductServices)
                    .LoadAsync();

                foreach (var service in productForClient.ProductServices)
                {
                    await RepositoryDbContext.Entry(service)
                        .Reference(c => c.Description)
                        .LoadAsync();
                    
                    await RepositoryDbContext.Entry(service.Description)
                        .Collection(c => c.Translations)
                        .Query()
                        .Where(t => t.Culture == culture)
                        .LoadAsync();
                }

            }
            
            return ProductForClientMapper.MapFromDomain(productForClient);
        }
    }
}