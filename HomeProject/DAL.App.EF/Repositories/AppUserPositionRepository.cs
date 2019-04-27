using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserPositionRepository : BaseRepository<AppUserPosition, AppDbContext>, IAppUserPositionRepository
    {
        public AppUserPositionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<AppUserPosition>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.AppUsers).ToListAsync();
        }

        public virtual async Task<List<AppUserPositionDTO>> GetAllWithAppUsersCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new AppUserPositionDTO()
                {
                    Id = c.Id,
                    AppUserPositionValue = c.PositionValue,
                    AppUsersCount = c.AppUsers.Count
                })
                .ToListAsync();
        }

    }
}