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
    public class WorkObjectRepository : BaseRepository<WorkObject, AppDbContext >, IWorkObjectRepository
    {
        public WorkObjectRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public override async Task<List<WorkObject>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .ToListAsync();
        }

        public override async Task<WorkObject> FindAsync(params object[] id)
        {
            var workObject = await base.FindAsync(id);

            if (workObject != null)
            {
                await RepositoryDbContext.Entry(workObject)
                    .Reference(c => c.Client).LoadAsync();
            }

            return workObject;
        }

        public virtual async Task<List<WorkObjectsDTO>> GetAllAsync()
        {
            return await RepositoryDbSet
                .Select(c => new WorkObjectsDTO()
                {
                    Id = c.Id,
                    Client = c.Client,
                    ClientId = c.ClientId,
                    WorkersOnObject = c.WorkersOnObject,
                    ProductsForClient = c.ProductsForClient,
                    From = c.From,
                    Until = c.Until
                })
                .ToListAsync();
        }
    }
}