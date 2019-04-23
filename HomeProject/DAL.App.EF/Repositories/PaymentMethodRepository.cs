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
    public class PaymentMethodRepository : BaseRepository<PaymentMethod, AppDbContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public override async Task<List<PaymentMethod>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Payments).ToListAsync();
        }

        public virtual async Task<List<PaymentMethodDTO>> GetAllWithPaymentsCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new PaymentMethodDTO()
                {
                    Id = c.Id,
                    PaymentMethodValue = c.PaymentMethodValue,
                    PaymentsCount = c.Payments.Count
                })
                .ToListAsync();
        }
    }
}