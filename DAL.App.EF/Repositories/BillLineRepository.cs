using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BillLineRepository : BaseRepository<BillLine>, IBillLineRepository
    {
        public BillLineRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<BillLine>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Bill)
                .ToListAsync();
        }

        public override async Task<BillLine> FindAsync(params object[] id)
        {
            var billLine = await base.FindAsync(id);

            if (billLine != null)
            {
                await RepositoryDbContext.Entry(billLine).Reference(c => c.Bill).LoadAsync();
            }

            return billLine;
        }
    }
}