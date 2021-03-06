using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IAppUserPositionRepository : IAppUserPositionRepository<DALAppDTO.AppUserPosition>
    {
        Task<List<DALAppDTO.AppUserPositionWithAppUsersCount>> GetAllWithAppUsersCountAsync();

    }

    public interface IAppUserPositionRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {

    }
}