using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;

namespace Contracts.BLL.App
{
    public  interface IAppUserInPositionService: IBaseEntityService<AppUserInPosition>, IAppUserInPositionRepository
    {
    }
}