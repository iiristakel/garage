using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkerPositionRepository : BaseRepository<WorkerPosition>, IWorkerPositionRepository
    {
        public WorkerPositionRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<WorkerPosition>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.WorkersInPosition).ToListAsync();
        }

        public virtual async Task<IEnumerable<WorkerPositionDTO>> GetAllWithWorkersCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new WorkerPositionDTO()
                {
                    Id = c.Id,
                    WorkerPositionValue = c.WorkerPositionValue,
                    WorkersCount = c.WorkersInPosition.Count
                })
                .ToListAsync();
        }

    }
}