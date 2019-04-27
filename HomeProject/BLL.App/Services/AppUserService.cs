using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;

namespace BLL.App.DTO
{
    public class AppUserService : BaseEntityService<AppUser, IAppUnitOfWork>, IAppUserService
    {
        public AppUserService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<AppUser>> AllAsync(int userId)
        {
            return await Uow.AppUsers.AllAsync();

        }
    }
}