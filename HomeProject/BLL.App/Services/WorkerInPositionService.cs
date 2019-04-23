using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class WorkerInPositionService : BaseEntityService<WorkerInPosition, IAppUnitOfWork>, IWorkerInPositionService
    {
        public WorkerInPositionService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }
}