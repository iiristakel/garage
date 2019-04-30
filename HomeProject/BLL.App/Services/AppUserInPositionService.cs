using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class AppUserInPositionService 
        : BaseEntityService<BLL.App.DTO.AppUserInPosition, DAL.App.DTO.AppUserInPosition, 
            IAppUnitOfWork>, IAppUserInPositionService
    {
        public AppUserInPositionService(IAppUnitOfWork uow) : base(uow, new AppUserInPositionMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.AppUserInPosition, Domain.AppUserInPosition>();
        }

        public async Task<List<AppUserInPosition>> AllForUserAsync(int userId)
        {
            return (await Uow.AppUsersInPositions
                .AllForUserAsync(userId))
                .Select(e => AppUserInPositionMapper
                .MapFromDAL(e)).ToList();
        }

        public async Task<AppUserInPosition> FindForUserAsync(int id, int userId)
        {
            return AppUserInPositionMapper.MapFromDAL( await Uow.AppUsersInPositions.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.AppUsersInPositions.BelongsToUserAsync(id, userId);
        }
    }
}