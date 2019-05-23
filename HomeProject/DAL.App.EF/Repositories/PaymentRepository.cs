using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Payment = DAL.App.DTO.Payment;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository 
        : BaseRepository<DAL.App.DTO.Payment, Domain.Payment,
            AppDbContext>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new PaymentMapper())
        {
        }
        public override async Task<List<DAL.App.DTO.Payment>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Bill)
                .ThenInclude(p => p.Comment)
                .ThenInclude(t => t.Translations)
                .Include(p => p.Client)
                .Include(p => p.PaymentMethod)
                .ThenInclude(p => p.PaymentMethodValue)
                .ThenInclude(t => t.Translations)
                .Select(e => PaymentMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
//        public override async Task<DAL.App.DTO.Payment> FindAsync(params object[] id)
//        {
//            var payment = await RepositoryDbSet.FindAsync(id);
//
//            if (payment != null)
//            {
//                await RepositoryDbContext.Entry(payment).Reference(c => c.Bill).LoadAsync();
//                await RepositoryDbContext.Entry(payment).Reference(c => c.Client).LoadAsync();
//                await RepositoryDbContext.Entry(payment).Reference(c => c.PaymentMethod).LoadAsync();
//          }
//            
//            return PaymentMapper.MapFromDomain(payment);
//        }

        public async Task<List<Payment>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(p => p.Bill)
                .ThenInclude(p => p.Comment)
                .ThenInclude(t => t.Translations)
                .Include(p => p.Client)
                .Include(p => p.PaymentMethod)
                .ThenInclude(p => p.PaymentMethodValue)
                .ThenInclude(t => t.Translations)
                .Where(c => c.Bill.AppUserId == userId)
                .Select(e => PaymentMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<Payment> FindForUserAsync(int id, int userId)
        {
            var payment = await RepositoryDbSet
                .Include(p => p.Bill)
                .ThenInclude(p => p.Comment)
                .ThenInclude(t => t.Translations)
                .Include(p => p.Client)
                .Include(p => p.PaymentMethod)
                .ThenInclude(p => p.PaymentMethodValue)
                .ThenInclude(t => t.Translations)
                .FirstOrDefaultAsync(m => m.Id == id && m.Bill.AppUserId == userId);

            return PaymentMapper.MapFromDomain(payment);        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.Bill.AppUserId == userId);
        }
    }
}