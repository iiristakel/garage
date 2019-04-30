using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserInPositionRepository
        : BaseRepository<DAL.App.DTO.AppUserInPosition, Domain.AppUserInPosition,
            AppDbContext>, IAppUserInPositionRepository
    {
        public AppUserInPositionRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new AppUserInPositionMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.AppUserInPosition>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.AppUserPosition)
                .Select(e => AppUserInPositionMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public override async Task<DAL.App.DTO.AppUserInPosition> FindAsync(params object[] id)
        {
            var workerInPosition = await base.FindAsync(id);

            if (workerInPosition != null)
            {
                await RepositoryDbContext.Entry(workerInPosition).Reference(c => c.AppUserPosition).LoadAsync();
            }

            return workerInPosition;
        }

        public async Task<List<DAL.App.DTO.AppUserInPosition>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.AppUserPosition)
                .Include(c => c.AppUser)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => AppUserInPositionMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<AppUserInPosition> FindForUserAsync(int id, int userId)
        {
            var appUserInPosition = await RepositoryDbSet
                .Include(c => c.AppUserPosition)
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUser.Id == userId);

            return AppUserInPositionMapper.MapFromDomain(appUserInPosition);
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUser.Id == userId);
        }
    }
}