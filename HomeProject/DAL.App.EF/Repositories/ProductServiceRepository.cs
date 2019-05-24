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

            var res = await RepositoryDbSet
                .Include(t => t.Description)
                .ThenInclude(t => t.Translations)
                .Select(c => new
                {
                    Id = c.Id,
                    Description = c.Description,
                    Translations = c.Description.Translations
                })
                .ToListAsync();

            var resultList = res.Select(c => new ProductService()
            {
                Id = c.Id,
                Description = c.Description.Translate()
            }).ToList();

            return resultList;
        }

        public override async Task<DAL.App.DTO.ProductService> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var productService = await RepositoryDbSet.FindAsync(id);

            if (productService != null)
            {
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
                .Include(m => m.Description)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);

            entityInDb.Description.SetTranslation(entity.Description);

            return entity;
        }
    }
}