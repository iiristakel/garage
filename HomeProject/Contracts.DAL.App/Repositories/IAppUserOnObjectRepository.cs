using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{

    public interface IAppUserOnObjectRepository : IAppUserOnObjectRepository<DALAppDTO.AppUserOnObject>
    {
    }

    public interface IAppUserOnObjectRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    { 
        Task<List<TDALEntity>> AllForWorkObjectAsync(int workObjectId);

//        Task<List<TDALEntity>> AllForUserAsync(int userId);
//        Task<TDALEntity> FindForUserAsync(int id, int userId);
//        Task<bool> BelongsToUserAsync(int id, int userId);
    }
    
}
