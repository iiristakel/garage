using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkerRepository : BaseRepository<Worker, AppDbContext>, IWorkerRepository
    {
        public WorkerRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<List<Worker>> AllAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(p => p.AppUser)
                .Where(p => p.AppUserId == userId)
                .Include(c =>c.WorkerOnTasks)
                .Include(d=> d.WorkerInPositions)
                .ToListAsync();
        }
        
        public override async Task<Worker> FindAsync(params object[] id)
        {
            var worker = await base.FindAsync(id);

            if (worker != null)
            {
                await RepositoryDbContext.Entry(worker).Reference(c => c.AppUser).LoadAsync();
            }
            
            return worker;
        }
    }
}