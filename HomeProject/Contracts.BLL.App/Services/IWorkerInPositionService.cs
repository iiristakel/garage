using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;

namespace Contracts.BLL.App
{
    public  interface IWorkerInPositionService: IBaseEntityService<WorkerInPosition>, IWorkerInPositionRepository
    {
    }
}