using System.Collections;
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
    public class BillLineRepository : BaseRepository<BillLine, AppDbContext>, IBillLineRepository
    {
        public BillLineRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public override async Task<List<BillLine>> AllAsync()
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
        
        public virtual async Task<List<BillLineDTO>> GetAllAsync()
        {
            return await RepositoryDbSet.Include(p => p.Bill)
                .Select(c => new BillLineDTO()
                {
                    Id = c.Id,
                    Bill = c.Bill,
                    BillId = c.BillId,
                    Product = c.Product,
                    Sum = c.Sum,
                    Amount = c.Amount,
                    DiscountPercent = c.DiscountPercent,
                    SumWithDiscount = c.Sum * (1 - c.DiscountPercent / 100)
                })
                .ToListAsync();
        }
    }
}