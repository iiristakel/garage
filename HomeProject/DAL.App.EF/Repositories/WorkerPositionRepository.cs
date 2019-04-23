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
    public class WorkerPositionRepository : BaseRepository<WorkerPosition, AppDbContext>, IWorkerPositionRepository
    {
        public WorkerPositionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<WorkerPosition>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.WorkersInPosition).ToListAsync();
        }

        public virtual async Task<List<WorkerPositionDTO>> GetAllWithWorkersCountAsync()
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