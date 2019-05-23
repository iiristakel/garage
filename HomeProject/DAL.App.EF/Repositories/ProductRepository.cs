using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Product = DAL.App.DTO.Product;

namespace DAL.App.EF.Repositories
{
    public class ProductRepository 
        : BaseRepository<DAL.App.DTO.Product, Domain.Product,
            AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new ProductMapper())
        {
        }
        
        public override async Task<List<Product>> AllAsync()
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(p => p.ProductName)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    ProductName = c.ProductName,
                    Translations = c.ProductName.Translations,
                    ProductCode = c.ProductCode,
                    Price = c.Price
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new Product()
            {
                Id = c.Id,
                ProductName = c.ProductName.Translate(),
                ProductCode = c.ProductCode,
                Price = c.Price
                     
            }).ToList();
            return resultList;

        }
        
        public override async Task<DAL.App.DTO.Product> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var product = await RepositoryDbSet.FindAsync(id);

            if (product != null)
            {
                await RepositoryDbContext.Entry(product)
                    .Reference(c => c.ProductName)
                    .LoadAsync();
                await RepositoryDbContext.Entry(product.ProductName)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            
            return ProductMapper.MapFromDomain(product);
        }
        
        public override Product Update(Product entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.ProductName)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.ProductName.SetTranslation(entity.ProductName);
            entityInDb.ProductCode = entity.ProductCode;
            entityInDb.Price = entity.Price;
            

            return entity;
        }

        
    }
}