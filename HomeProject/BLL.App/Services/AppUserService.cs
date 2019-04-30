using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO.Identity;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class AppUserService 
        : BaseEntityService<BLL.App.DTO.Identity.AppUser, DAL.App.DTO.Identity.AppUser,
            IAppUnitOfWork>, IAppUserService
    {
        public AppUserService(IAppUnitOfWork uow) : base(uow, new AppUserMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Identity.AppUser, Domain.Identity.AppUser>();
        }

        public async Task<List<AppUser>> AllForUserAsync(int userId)
        {
            return (await Uow.AppUsers
                    .AllForUserAsync(userId))
                .Select(e => AppUserMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<AppUser> FindForUserAsync(int id, int userId)
        {
            return AppUserMapper.MapFromDAL( await Uow.AppUsers.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.AppUsers.BelongsToUserAsync(id, userId);
        }
    }
}