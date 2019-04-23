using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkerOnObjectRepository : BaseRepository<WorkerOnObject,AppDbContext>, IWorkerOnObjectRepository
    {
        public WorkerOnObjectRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<WorkerOnObject>> AllAsync()
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
                await RepositoryDbContext.Entry(workerOnObject).Reference(c => c.WorkObject).LoadAsync();
                await RepositoryDbContext.Entry(workerOnObject).Reference(c => c.Worker).LoadAsync();

            }
            
            return workerOnObject;
        }
    }
}