using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        public override async Task<IEnumerable<Payment>> AllAsync()
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
                await RepositoryDbSet
                    .Include(p => p.Bill)
                    .Include(p => p.Client)
                    .Include(p => p.PaymentMethod)
                    .ToListAsync();            }
            
            return payment;
        }
    }
}