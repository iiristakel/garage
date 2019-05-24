using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserPositionRepository 
        : BaseRepository<DAL.App.DTO.AppUserPosition, Domain.AppUserPosition,
            AppDbContext>, IAppUserPositionRepository
    {
        public AppUserPositionRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new AppUserPositionMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.AppUserPosition>> AllAsync()
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(a => a.AppUserPositionValue)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    AppUserPositionValue = c.AppUserPositionValue,
                    Translations = c.AppUserPositionValue.Translations
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new AppUserPosition()
            {
                Id = c.Id,
                AppUserPositionValue = c.AppUserPositionValue.Translate()
                     
            }).ToList();
            return resultList;
        }

        public virtual async Task<List<AppUserPositionWithAppUsersCount>> GetAllWithAppUsersCountAsync()
        {           
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(a => a.AppUserPositionValue)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    AppUserPositionValue = c.AppUserPositionValue,
                    Translations = c.AppUserPositionValue.Translations,
                    AppUsersCount = c.AppUsersInPosition.Count
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new AppUserPositionWithAppUsersCount()
            {
                Id = c.Id,
                AppUsersCount = c.AppUsersCount,
                AppUserPositionValue = c.AppUserPositionValue.Translate()
                     
            }).ToList();
            return resultList;

        }

        
        public override async Task<DAL.App.DTO.AppUserPosition> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var appUserPosition = await RepositoryDbSet.FindAsync(id);

            if (appUserPosition != null)
            {
               
                await RepositoryDbContext.Entry(appUserPosition)
                    .Reference(c => c.AppUserPositionValue)
                    .LoadAsync();
                await RepositoryDbContext.Entry(appUserPosition.AppUserPositionValue)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            
            return AppUserPositionMapper.MapFromDomain(appUserPosition);
        }
        
        public override AppUserPosition Update(AppUserPosition entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.AppUserPositionValue)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.AppUserPositionValue.SetTranslation(entity.AppUserPositionValue);

            return entity;
        }


    }
}