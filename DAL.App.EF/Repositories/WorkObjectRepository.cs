using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkObjectRepository : BaseRepository<WorkObject>, IWorkObjectRepository
    {
        public WorkObjectRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<WorkObject>> AllAsync()
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
    }
}