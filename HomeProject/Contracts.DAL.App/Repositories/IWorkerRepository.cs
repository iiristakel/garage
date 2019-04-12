using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkerRepository: IBaseRepositoryAsync<Worker>
    {
        //add here custom methods
        Task<IEnumerable<Worker>> AllAsync(int userId);
    }
}