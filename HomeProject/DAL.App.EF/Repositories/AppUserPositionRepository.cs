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
            return await RepositoryDbSet
                .Select(e => AppUserPositionMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public virtual async Task<List<AppUserPositionWithAppUsersCount>> GetAllWithAppUsersCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new AppUserPositionWithAppUsersCount()
                {
                    Id = c.Id,
                    AppUserPositionValue = c.AppUserPositionValue,
                    AppUsersCount = c.AppUsers.Count
                })
                .ToListAsync();
        }

    }
}