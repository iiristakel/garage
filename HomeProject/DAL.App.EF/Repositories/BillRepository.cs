using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Bill = DAL.App.DTO.Bill;

namespace DAL.App.EF.Repositories
{
    public class BillRepository 
        : BaseRepository<DAL.App.DTO.Bill, Domain.Bill,
            AppDbContext>, IBillRepository
    {
        public BillRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new BillMapper())
        {
        }


        public override async Task<List<DAL.App.DTO.Bill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .Include(p => p.AppUser)
                .Include(p => p.Payments)
                .Select(e => BillMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public override async Task<DAL.App.DTO.Bill> FindAsync(params object[] id)
        {
            var bill = await RepositoryDbSet.FindAsync(id);

            if (bill != null)
            {
                await RepositoryDbContext.Entry(bill).Reference(c => c.Client).LoadAsync();
                await RepositoryDbContext.Entry(bill).Reference(c => c.AppUser).LoadAsync();
                

            }
            
            return BillMapper.MapFromDomain(bill);
        }

        public virtual async Task<List<BillWithPaymentsCount>> GetAllWithPaymentsCountAsync()
        {
            return await RepositoryDbSet
                .Select(c => new BillWithPaymentsCount()
                {
                    Id = c.Id,
                    Client = ClientMapper.MapFromDomain(c.Client),
                    ClientId = c.ClientId,
                    PaymentsCount = c.Payments.Count,
                    ArrivalFee = c.ArrivalFee,
                    SumWithoutTaxes = c.SumWithOutTaxes,
                    TaxPercent = c.TaxPercent,
                    FinalSum = c.SumWithOutTaxes * (1 + (c.TaxPercent / 100)),
                    DateTime = c.DateTime,
                    InvoiceNr = c.InvoiceNr,
                    Comment = c.Comment
                })
                .ToListAsync();
        }

        public async Task<List<Bill>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Client)
                .Include(c => c.AppUser)
                .Include(c => c.Payments)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => BillMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<Bill> FindForUserAsync(int id, int userId)
        {
            return BillMapper.MapFromDomain(
                await RepositoryDbSet
                    .Include(p => p.Client)
                    .Include(p => p.AppUser)
                    .Include(c => c.Payments)
                .FirstOrDefaultAsync(p => p.Id == id && p.AppUserId == userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(p => p.Id == id && p.AppUserId == userId);
        }
    }
}