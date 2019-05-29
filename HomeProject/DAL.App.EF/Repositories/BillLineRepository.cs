using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(p => p.Product)
                .ThenInclude(t => t.Translations)
                .Include(p => p.Bill)
                .ThenInclude(p => p.Comment)
                .ThenInclude(p => p.Translations)
                .Select(e => BillLineMapper.MapFromDomain(e))
                .ToListAsync();

            return res;
        }
        
        public async Task<List<DAL.App.DTO.BillLine>> AllForBillAsync(int? billId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(p => p.Product)
                .ThenInclude(t => t.Translations)
                .Include(p => p.Bill)
                .ThenInclude(p => p.Comment)
                .ThenInclude(p => p.Translations)
                .Where(p => p.BillId == billId)
                .Select(e => BillLineMapper.MapFromDomain(e))
                .ToListAsync();

            return res;
        }

        public override async Task<DAL.App.DTO.BillLine> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var billLine = await RepositoryDbSet.FindAsync(id);

            if (billLine != null)
            {
                await RepositoryDbContext.Entry(billLine)
                    .Reference(c => c.Bill)
                    .LoadAsync();
                await RepositoryDbContext.Entry(billLine.Bill)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(billLine.Bill.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(billLine)
                    .Reference(c => c.Product)
                    .LoadAsync();
                await RepositoryDbContext.Entry(billLine.Product)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();

            }

            return BillLineMapper.MapFromDomain(billLine);
        }


        public async Task<List<BillLine>> AllForUserAsync(int userId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(p => p.Bill)
                .Include(p => p.Product)
                .ThenInclude(t => t.Translations)
                .Where(p => p.Bill.WorkObject.AppUsersOnObject.Any(q => q.AppUserId == userId))
                .Select(e => BillLineMapper.MapFromDomain(e))
                .ToListAsync();

            return res;
        }

        public async Task<BillLine> FindForUserAsync(int id, int userId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var contact = await RepositoryDbSet
                .Include(p => p.Product)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Bill)  //need to include more?
                .FirstOrDefaultAsync(m => m.Id == id && m.Bill.WorkObject.AppUsersOnObject.Any(p => p.AppUserId == userId));

            return BillLineMapper.MapFromDomain(contact);        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.Bill.WorkObject.AppUsersOnObject.Any(p => p.AppUserId == userId));
        }
    }
}