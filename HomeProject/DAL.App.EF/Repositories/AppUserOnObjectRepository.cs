using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.App.DTO;

namespace DAL.App.EF.Repositories
{
    public class AppUserOnObjectRepository 
        : BaseRepository<DAL.App.DTO.AppUserOnObject, Domain.AppUserOnObject,
            AppDbContext>, IAppUserOnObjectRepository
    {
        public AppUserOnObjectRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new AppUserOnObjectMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.AppUserOnObject>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.WorkObject)
                .Include(c => c.AppUser)
                .Select(e => AppUserOnObjectMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public override async Task<DAL.App.DTO.AppUserOnObject> FindAsync(params object[] id)
        {
            var appUserOnObject = await RepositoryDbSet.FindAsync(id);

            if (appUserOnObject != null)
            {
                await RepositoryDbContext.Entry(appUserOnObject)
                    .Reference(c => c.WorkObject).LoadAsync();

            }
            
            return AppUserOnObjectMapper.MapFromDomain(appUserOnObject);
        }

        public async Task<List<AppUserOnObject>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.WorkObject)
                .Include(c => c.AppUser)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => AppUserOnObjectMapper.MapFromDomain(e))
                .ToListAsync();        
        }

        public async Task<AppUserOnObject> FindForUserAsync(int id, int userId)
        {
            var appUserOnObject = await RepositoryDbSet
                .Include(c => c.WorkObject)
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUser.Id == userId);

            return AppUserOnObjectMapper.MapFromDomain(appUserOnObject) ;        
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUser.Id == userId);
        }
    }
}