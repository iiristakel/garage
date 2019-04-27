using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class AppUserOnObjectService : BaseEntityService<AppUserOnObject, IAppUnitOfWork>, IAppUserOnObjectService
    
    {
        public AppUserOnObjectService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}