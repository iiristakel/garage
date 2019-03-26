using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(IDataContext dataContext) : base(dataContext)
        {
        }


        public override async Task<IEnumerable<Bill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .ToListAsync();
        }
        
        public override async Task<Bill> FindAsync(params object[] id)
        {
            var bill = await base.FindAsync(id);

            if (bill != null)
            {
                await RepositoryDbContext.Entry(bill).Reference(c => c.Client).LoadAsync();
            }
            
            return bill;
        }
    }
}