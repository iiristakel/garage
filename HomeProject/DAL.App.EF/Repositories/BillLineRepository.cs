using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using BillLine = DAL.App.DTO.BillLine;

namespace DAL.App.EF.Repositories
{
    public class BillLineRepository 
        : BaseRepository<DAL.App.DTO.BillLine, Domain.BillLine,
            AppDbContext>, IBillLineRepository
    {
        public BillLineRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new BillLineMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.BillLine>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Bill)
                .Select(c => new BillLine()
                {
                    Id = c.Id,
                    Bill = BillMapper.MapFromDomain(c.Bill),
                    BillId = c.BillId,
                    Product = c.Product,
                    Sum = c.Sum,
                    Amount = c.Amount,
                    DiscountPercent = c.DiscountPercent,
                    SumWithDiscount = c.Sum * (1 - c.DiscountPercent / 100)
                })
                .ToListAsync();
        }

        public override async Task<DAL.App.DTO.BillLine> FindAsync(params object[] id)
        {
            var billLine = await RepositoryDbSet.FindAsync(id);

            if (billLine != null)
            {
                await RepositoryDbContext.Entry(billLine)
                    .Reference(c => c.Bill).LoadAsync();
            }

            return BillLineMapper.MapFromDomain(billLine);
        }


        public async Task<List<BillLine>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Bill)
                .Where(p => p.Bill.AppUserId == userId)
                .Select(e => BillLineMapper.MapFromDomain(e))
                .ToListAsync();

        }

        public async Task<BillLine> FindForUserAsync(int id, int userId)
        {
            var contact = await RepositoryDbSet
                .Include(c => c.Bill)
                .FirstOrDefaultAsync(m => m.Id == id && m.Bill.AppUserId == userId);

            return BillLineMapper.MapFromDomain(contact);        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.Bill.AppUserId == userId);
        }
    }
}