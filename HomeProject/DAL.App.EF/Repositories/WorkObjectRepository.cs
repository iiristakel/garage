using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using WorkObject = DAL.App.DTO.WorkObject;

namespace DAL.App.EF.Repositories
{
    public class WorkObjectRepository 
        : BaseRepository<DAL.App.DTO.WorkObject, Domain.WorkObject, 
            AppDbContext >, IWorkObjectRepository
    {
        public WorkObjectRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new WorkObjectMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.WorkObject>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .ThenInclude(q => q.Bills)
                .Include(p => p.AppUsersOnObject)
                .ThenInclude(p => p.AppUser)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p => p.Product)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p => p.Client)
                .Select(e => WorkObjectMapper.MapFromDomain(e))
                .ToListAsync();
            
        }

        public override async Task<DAL.App.DTO.WorkObject> FindAsync(params object[] id)
        {
            
            var workObject = await RepositoryDbSet
                .Include(c => c.Client)
                .ThenInclude(q => q.Bills)
                .Include(p => p.AppUsersOnObject)
                .ThenInclude(p => p.AppUser)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p  => p.Product)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p => p.Client)
                .FirstOrDefaultAsync(m => m.Id == (int) id[0]);


            return WorkObjectMapper.MapFromDomain(workObject);
        }

        public async Task<List<DAL.App.DTO.WorkObject>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Client)
                .ThenInclude(q => q.Bills)
                .Include(p => p.AppUsersOnObject)
                .ThenInclude(p => p.AppUser)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p => p.Product)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p => p.Client)
                .Where(p => p.AppUsersOnObject.Any(q => q.AppUserId == userId))
                .Select(e => WorkObjectMapper.MapFromDomain(e))
                .ToListAsync();
        }


        public async Task<WorkObject> FindForUserAsync(int id, int userId)
        {
            var workObject = await RepositoryDbSet
                .Include(c => c.Client)
                .ThenInclude(q => q.Bills)
                .Include(p => p.AppUsersOnObject)
                .ThenInclude(p => p.AppUser)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p  => p.Product)
                .Include(p => p.ProductsForClient)
                .ThenInclude(p => p.Client)
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUsersOnObject.Any(q => q.AppUserId == userId));

            return WorkObjectMapper.MapFromDomain(workObject);        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUsersOnObject.Any(q => q.AppUserId == userId));
        }
    }
}