using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;

namespace BLL.App.DTO
{
    public class AppUserPositionService : BaseEntityService<AppUserPosition, IAppUnitOfWork>, IAppUserPositionService
    {
        public AppUserPositionService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<AppUserPositionDTO>> GetAllWithAppUsersCountAsync()
        {
            return await Uow.AppUsersPositions.GetAllWithAppUsersCountAsync();
        }
    }
}