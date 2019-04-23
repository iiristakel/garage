using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;

namespace Contracts.BLL.App
{
    public  interface IWorkerService: IBaseEntityService<Worker>, IWorkerRepository
    {
    }
}