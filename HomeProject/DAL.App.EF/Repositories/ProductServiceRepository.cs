using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductServiceRepository
        : BaseRepository<DAL.App.DTO.ProductService, Domain.ProductService,
            AppDbContext>, IProductServiceRepository
    {
        public ProductServiceRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new ProductServiceMapper())
        {
        }

        public override async Task<List<ProductService>> AllAsync()
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            return await RepositoryDbSet
                .Include(p => p.WorkObject)
                .Include(p => p.ProductForClient)
                .Include(t => t.Description)
                .ThenInclude(t => t.Translations)
                .Select(c => ProductServiceMapper.MapFromDomain(c))
                .ToListAsync();

        }
        
        public async Task<List<ProductService>> AllForClientProductAsync(int? productForClientId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var res = await RepositoryDbSet
                .Include(p => p.ProductForClient)
                .Include(p => p.WorkObject)
                .Include(t => t.Description)
                .ThenInclude(t => t.Translations)
                .Where(p => p.ProductForClientId == productForClientId)
                .Select(e => ProductServiceMapper.MapFromDomain(e))
                .ToListAsync();

            return res;
        }

        public async Task<List<ProductService>> AllForWorkObjectAsync(int workObjectId)
        {

            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            return await RepositoryDbSet
                .Include(p => p.WorkObject)
                .Include(p => p.ProductForClient)
                .ThenInclude(p=> p.Product)
                .ThenInclude(p=> p.ProductName)
                .ThenInclude(p=> p.Translations)
                .Include(t => t.Description)
                .ThenInclude(t => t.Translations)
                .Where(p=> p.WorkObjectId == workObjectId)
                .Select(c => ProductServiceMapper.MapFromDomain(c))
                .ToListAsync();
            
        }


        public override async Task<DAL.App.DTO.ProductService> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var productService = await RepositoryDbSet.FindAsync(id);

            if (productService != null)
            {
                await RepositoryDbContext.Entry(productService)
                    .Reference(c => c.ProductForClient)
                    .LoadAsync();
                await RepositoryDbContext.Entry(productService)
                    .Reference(c => c.WorkObject)
                    .LoadAsync();
                await RepositoryDbContext.Entry(productService)
                    .Reference(c => c.Description)
                    .LoadAsync();
                await RepositoryDbContext.Entry(productService.Description)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }

            return ProductServiceMapper.MapFromDomain(productService);
        }

        public override ProductService Update(ProductService entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(p => p.ProductForClient)
                .Include(p => p.WorkObject)
                .Include(m => m.Description)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);

            entityInDb.Description.SetTranslation(entity.Description);

            return entity;
        }
    }
}