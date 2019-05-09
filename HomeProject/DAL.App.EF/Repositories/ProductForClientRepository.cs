using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using System.Linq;
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
                .Include(p => p.Client)
                .Include(p => p.Product)
                .Include(p => p.WorkObject)
                .Select(e => ProductForClientMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public override async Task<DAL.App.DTO.ProductForClient> FindAsync(params object[] id)
        {
            var productForClient = await RepositoryDbSet.FindAsync(id);

            if (productForClient != null)
            {
                await RepositoryDbContext.Entry(productForClient).Reference(c => c.Client).LoadAsync();
                await RepositoryDbContext.Entry(productForClient).Reference(c => c.Product).LoadAsync();
                await RepositoryDbContext.Entry(productForClient).Reference(c => c.WorkObject).LoadAsync();

            }
            
            return ProductForClientMapper.MapFromDomain(productForClient);
        }
    }
}