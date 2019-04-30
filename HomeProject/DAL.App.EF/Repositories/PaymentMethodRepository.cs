using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentMethodRepository 
        : BaseRepository<DAL.App.DTO.PaymentMethod, Domain.PaymentMethod,
            AppDbContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new PaymentMethodMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.PaymentMethod>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Payments)
                .Select(e => PaymentMethodMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public virtual async Task<List<PaymentMethodWithPaymentsCount>> GetAllWithPaymentsCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new PaymentMethodWithPaymentsCount()
                {
                    Id = c.Id,
                    PaymentMethodValue = c.PaymentMethodValue,
                    PaymentsCount = c.Payments.Count
                })
                .ToListAsync();
        }
    }
}