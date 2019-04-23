using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class ProductForClientService : BaseEntityService<ProductForClient, IAppUnitOfWork>, IProductForClientService
    {
        public ProductForClientService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }
}