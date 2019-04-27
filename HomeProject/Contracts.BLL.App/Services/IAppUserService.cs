using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;
using Domain.Identity;

namespace Contracts.BLL.App
{
    public  interface IAppUserService: IBaseEntityService<AppUser>, IAppUserRepository
    {
    }
}