using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class AppUserInPositionService : BaseEntityService<AppUserInPosition, IAppUnitOfWork>, IAppUserInPositionService
    {
        public AppUserInPositionService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }
}