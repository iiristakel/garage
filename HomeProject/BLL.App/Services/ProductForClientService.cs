using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ProductForClient = BLL.App.DTO.ProductForClient;

namespace BLL.App.Services
{
    public class ProductForClientService 
        : BaseEntityService<BLL.App.DTO.ProductForClient, DAL.App.DTO.ProductForClient,
            IAppUnitOfWork>, IProductForClientService
    {
        public ProductForClientService(IAppUnitOfWork uow) : base(uow, new ProductForClientMapper())
        {
            ServiceRepository = Uow.ProductsForClients;

        }
    }
}