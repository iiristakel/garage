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
    public class WorkerPositionService : BaseEntityService<WorkerPosition, IAppUnitOfWork>, IWorkerPositionService
    {
        public WorkerPositionService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<WorkerPositionDTO>> GetAllWithWorkersCountAsync()
        {
            return await Uow.WorkersPositions.GetAllWithWorkersCountAsync();
        }
    }
}