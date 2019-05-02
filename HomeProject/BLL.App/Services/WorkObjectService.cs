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
    public class WorkObjectService  
        : BaseEntityService<BLL.App.DTO.WorkObject, DAL.App.DTO.WorkObject,
            IAppUnitOfWork>, IWorkObjectService
    {
        public WorkObjectService(IAppUnitOfWork uow) : base(uow, new WorkObjectMapper())
        {
            ServiceRepository = Uow.WorkObjects;

        }

        public async Task<List<DTO.WorkObject>> GetAllAsync()
        {
            return (await Uow.WorkObjects.AllAsync())
                .Select(e => WorkObjectMapper.MapFromDAL(e))
                .ToList();
        }

        public async Task<List<WorkObject>> AllForUserAsync(int userId)
        {
            return (await Uow.WorkObjects
                    .AllForUserAsync(userId))
                .Select(e => WorkObjectMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<WorkObject> FindForUserAsync(int id, int userId)
        {
            return WorkObjectMapper.MapFromDAL( await Uow.WorkObjects.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.WorkObjects.BelongsToUserAsync(id, userId);
        }
    }
}