using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserInPositionRepository : BaseRepository<AppUserInPosition, AppDbContext>, IAppUserInPositionRepository
    {
        public AppUserInPositionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<AppUserInPosition>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.AppUserPosition)
                .ToListAsync();
        }
        
        public override async Task<AppUserInPosition> FindAsync(params object[] id)
        {
            var workerInPosition = await base.FindAsync(id);

            if (workerInPosition != null)
            {
                await RepositoryDbContext.Entry(workerInPosition).Reference(c => c.AppUserPosition).LoadAsync();

            }
            
            return workerInPosition;
        }
    }
}