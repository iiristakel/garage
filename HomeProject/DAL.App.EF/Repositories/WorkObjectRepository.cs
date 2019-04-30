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
                .Include(p => p.AppUsersOnObject)
                .Select(c => new WorkObject()
                {
                    Id = c.Id,
                    Client = ClientMapper.MapFromDomain(c.Client),
                    ClientId = c.ClientId,
                    From = c.From,
                    Until = c.Until
                })
                .ToListAsync();
        }

        public override async Task<DAL.App.DTO.WorkObject> FindAsync(params object[] id)
        {
            var workObject = await base.FindAsync(id);

            if (workObject != null)
            {
                await RepositoryDbContext.Entry(workObject)
                    .Reference(c => c.Client).LoadAsync();
            }

            return workObject;
        }


        public async Task<List<WorkObject>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Client)
                .Include(p => p.AppUsersOnObject)
                .Where(p => p.AppUsersOnObject.Any(q => q.AppUserId == userId))
                .Select(e => WorkObjectMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<WorkObject> FindForUserAsync(int id, int userId)
        {
            var contact = await RepositoryDbSet
                .Include(c => c.Client)
                .Include(p => p.AppUsersOnObject.Where(q => q.AppUserId == userId))
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUsersOnObject.Any(q => q.AppUserId == userId));

            return WorkObjectMapper.MapFromDomain(contact);        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUsersOnObject.Any(q => q.AppUserId == userId));
        }
    }
}