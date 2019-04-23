using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkerRepository: IBaseRepository<Worker>
    {
        //add here custom methods
        Task<List<Worker>> AllAsync(int userId);
    }
}