using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class AppUserPositionService
        : BaseEntityService<BLL.App.DTO.AppUserPosition, DAL.App.DTO.AppUserPosition,
            IAppUnitOfWork>, IAppUserPositionService
    {
        public AppUserPositionService(IAppUnitOfWork uow) : base(uow, new AppUserPositionMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.AppUserPosition, Domain.AppUserPosition>();
        }

        public async Task<List<AppUserPositionWithAppUsersCount>> GetAllWithAppUsersCountAsync()
        {
            
            return (await Uow.AppUsersPositions.GetAllWithAppUsersCountAsync())
                .Select(e => AppUserPositionMapper
                    .MapFromDAL(e)).ToList();

        }
    }
}