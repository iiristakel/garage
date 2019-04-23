using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<Payment,AppDbContext>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        public override async Task<List<Payment>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Bill)
                .Include(p => p.Client)
                .Include(p => p.PaymentMethod)
                .ToListAsync();
        }
        
        public override async Task<Payment> FindAsync(params object[] id)
        {
            var payment = await base.FindAsync(id);

            if (payment != null)
            {
                await RepositoryDbContext.Entry(payment).Reference(c => c.Bill).LoadAsync();
                await RepositoryDbContext.Entry(payment).Reference(c => c.Client).LoadAsync();
                await RepositoryDbContext.Entry(payment).Reference(c => c.PaymentMethod).LoadAsync();
          }
            
            return payment;
        }
    }
}