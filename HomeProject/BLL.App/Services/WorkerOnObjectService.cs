using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class WorkerOnObjectService : BaseEntityService<WorkerOnObject, IAppUnitOfWork>, IWorkerOnObjectService
    
    {
        public WorkerOnObjectService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}