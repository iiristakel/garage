using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class WorkerService : BaseEntityService<Worker, IAppUnitOfWork>, IWorkerService
    {
        public WorkerService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<Worker>> AllAsync(int userId)
        {
            return await Uow.Workers.AllAsync();

        }
    }
}