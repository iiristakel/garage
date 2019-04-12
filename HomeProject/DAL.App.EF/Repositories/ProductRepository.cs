using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public virtual async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            return await RepositoryDbSet
                .Select(c => new ProductDTO()
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