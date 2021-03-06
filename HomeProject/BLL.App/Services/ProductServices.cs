using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ProductService 
        : BaseEntityService<BLL.App.DTO.Product, DAL.App.DTO.Product,
            IAppUnitOfWork>, IProductService
    {
        public ProductService(IAppUnitOfWork uow) : base(uow, new ProductMapper())
        {
            ServiceRepository = Uow.Products;

        }

        
    }
}