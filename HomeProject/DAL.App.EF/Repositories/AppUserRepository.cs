using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser, AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<List<AppUser>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c =>c.Objects)
                .Include(d=> d.Positions)
                .ToListAsync();
        }
        
        public override async Task<AppUser> FindAsync(params object[] id)
        {
            var appUser = await base.FindAsync(id);

            if (appUser != null)
            {
                await RepositoryDbContext.Entry(appUser).Reference(c => c.Objects).LoadAsync();
                await RepositoryDbContext.Entry(appUser).Reference(c => c.Positions).LoadAsync();

            }
            
            return appUser;
        }
    }
}