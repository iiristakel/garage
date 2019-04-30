using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
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
        
        public virtual async Task<List<Product>> AllAsync()
        {
            return await RepositoryDbSet
                .Select(c => new Product()
                {
                    Id = c.Id,
                    ProductName = c.ProductName,
                    ProductCode = c.ProductCode,
                    Price = c.Price
                })
                .ToListAsync();
        }
        
    }
}