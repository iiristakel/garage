using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using AppUser = DAL.App.DTO.Identity.AppUser;

namespace DAL.App.EF.Repositories
{
    public class AppUserRepository
        : BaseRepository<DAL.App.DTO.Identity.AppUser, Domain.Identity.AppUser,
            AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new AppUserMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.Identity.AppUser>> AllAsync()
        {
            return await RepositoryDbSet
//                .Include(c =>c.AppUserOnObjects)
                .Include(d => d.AppUserInPositions)
                .ThenInclude(d => d.AppUserPosition)
                .ThenInclude(d => d.AppUserPositionValue)
                .ThenInclude(d => d.Translations)
                .Select(e => AppUserMapper.MapFromDomain(e))
                .ToListAsync();
        }


        public override async Task<DAL.App.DTO.Identity.AppUser> FindAsync(params object[] id)
        {
//            return await RepositoryDbSet
//                    .Include(d => d.AppUserInPositions)
//                    .ThenInclude(d => d.AppUserPosition)
//                    .ThenInclude(d => d.AppUserPositionValue)
//                    .ThenInclude(d => d.Translations)
//                    .Select(p => AppUserMapper.MapFromDomain(p))
//                    .FirstOrDefaultAsync(p => p.Id == (int) id[0]);

            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var appUser = await RepositoryDbSet.FindAsync(id);

            if (appUser != null)
            {
                await RepositoryDbContext.Entry(appUser)
                    .Collection(c => c.AppUserInPositions)
                    .LoadAsync();
                foreach (var appUserInPosition in appUser.AppUserInPositions)
                {
                    await RepositoryDbContext.Entry(appUserInPosition)
                        .Reference(c => c.AppUserPosition)
                        .LoadAsync();
                    await RepositoryDbContext.Entry(appUserInPosition.AppUserPosition)
                        .Reference(c => c.AppUserPositionValue)
                        .LoadAsync();
                    await RepositoryDbContext.Entry(appUserInPosition.AppUserPosition.AppUserPositionValue)
                        .Collection(c => c.Translations)
                        .Query()
                        .Where(t => t.Culture == culture)
                        .LoadAsync();
                }
            }

            return AppUserMapper.MapFromDomain(appUser);
        }


        public async Task<List<AppUser>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.AppUserOnObjects)
                .Include(d => d.AppUserInPositions)
                .ThenInclude(f => f.AppUserPosition)
                .ThenInclude(d => d.AppUserPositionValue)
                .ThenInclude(d => d.Translations)
                .Where(c => c.Id == userId)
                .Select(e => AppUserMapper.MapFromDomain(e))
                .ToListAsync();
        }
//
//        public async Task<AppUser> FindForUserAsync(int id, int userId)
//        {
//            return AppUserMapper.MapFromDomain(
//                await RepositoryDbSet
//                    .Include(c =>c.AppUserOnObjects)
//                    .Include(d=> d.AppUserInPositions)
//                    .Include(e => e.Bills)
//                .FirstOrDefaultAsync(p => p.Id == id && p.Id == userId));
//        }

//        public async Task<bool> BelongsToUserAsync(int id, int userId)
//        {
//            return await RepositoryDbSet.AnyAsync(p => p.Id == id && p.Id == userId);
//        }
//        
    }
}