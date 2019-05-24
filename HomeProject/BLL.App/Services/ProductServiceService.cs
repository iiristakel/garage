using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ProductServiceService
        : BaseEntityService<BLL.App.DTO.ProductService, DAL.App.DTO.ProductService,
            IAppUnitOfWork>, IProductServiceService
    {
        public ProductServiceService(IAppUnitOfWork uow) : base(uow, new ProductServiceMapper())
        {
            ServiceRepository = Uow.ProductsServices;

        }

    }
}