using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public  interface IAppUserPositionService
        : IBaseEntityService<BLLAppDTO.AppUserPosition>, 
            IAppUserPositionRepository<BLLAppDTO.AppUserPosition>
    {
        Task<List<BLLAppDTO.AppUserPositionWithAppUsersCount>> GetAllWithAppUsersCountAsync();

    }
}