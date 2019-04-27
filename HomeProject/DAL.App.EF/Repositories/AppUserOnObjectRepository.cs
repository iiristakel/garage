using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserOnObjectRepository : BaseRepository<AppUserOnObject,AppDbContext>, IAppUserOnObjectRepository
    {
        public AppUserOnObjectRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<AppUserOnObject>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.WorkObject)
                .ToListAsync();
        }
        
        public override async Task<AppUserOnObject> FindAsync(params object[] id)
        {
            var workerOnObject = await base.FindAsync(id);

            if (workerOnObject != null)
            {
                await RepositoryDbContext.Entry(workerOnObject).Reference(c => c.WorkObject).LoadAsync();

            }
            
            return workerOnObject;
        }
    }
}