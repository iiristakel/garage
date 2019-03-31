using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkerInPositionRepository : BaseRepository<WorkerInPosition>, IWorkerInPositionRepository
    {
        public WorkerInPositionRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<WorkerInPosition>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Worker)
                .Include(p => p.WorkerPosition)
                .ToListAsync();
        }
        
        public override async Task<WorkerInPosition> FindAsync(params object[] id)
        {
            var workerInPosition = await base.FindAsync(id);

            if (workerInPosition != null)
            {
                await RepositoryDbContext.Entry(workerInPosition).Reference(c => c.Worker).LoadAsync();
                await RepositoryDbContext.Entry(workerInPosition).Reference(c => c.WorkerPosition).LoadAsync();

            }
            
            return workerInPosition;
        }
    }
}