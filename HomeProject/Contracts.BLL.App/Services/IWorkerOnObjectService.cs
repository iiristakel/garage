using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;

namespace Contracts.BLL.App
{
    public  interface IWorkerOnObjectService: IBaseEntityService<WorkerOnObject>, IWorkerOnObjectRepository
    {
    }
}