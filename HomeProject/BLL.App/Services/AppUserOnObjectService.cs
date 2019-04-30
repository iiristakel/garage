using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using AppUserOnObject = BLL.App.DTO.AppUserOnObject;

namespace BLL.App.Services
{
    public class AppUserOnObjectService 
        : BaseEntityService<BLL.App.DTO.AppUserOnObject, DAL.App.DTO.AppUserOnObject, 
                IAppUnitOfWork>, IAppUserOnObjectService
    
    {
        public AppUserOnObjectService(IAppUnitOfWork uow) : base(uow, new AppUserOnObjectMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.AppUserOnObject, Domain.AppUserOnObject>();

        }

        public async Task<List<AppUserOnObject>> AllForUserAsync(int userId)
        {
            return (await Uow.AppUsersOnObjects
                    .AllForUserAsync(userId))
                .Select(e => AppUserOnObjectMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<AppUserOnObject> FindForUserAsync(int id, int userId)
        {
            return AppUserOnObjectMapper.MapFromDAL( await Uow.AppUsersOnObjects.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.AppUsersOnObjects.BelongsToUserAsync(id, userId);
        }
    }
}