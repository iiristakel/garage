using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkerOnObjectRepository : BaseRepository<WorkerOnObject>, IWorkerOnObjectRepository
    {
        public WorkerOnObjectRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<WorkerOnObject>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.WorkObject)
                .Include(p => p.Worker)
                .ToListAsync();
        }
        
        public override async Task<WorkerOnObject> FindAsync(params object[] id)
        {
            var workerOnObject = await base.FindAsync(id);

            if (workerOnObject != null)
            {
                 await RepositoryDbSet
                    .Include(p => p.WorkObject)
                    .Include(p => p.Worker)
                    .ToListAsync();
            }
            
            return workerOnObject;
        }
    }
}