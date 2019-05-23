using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using PaymentMethod = Domain.PaymentMethod;

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
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
//                .Include(p => p.Payments)
                .Include(p =>p.PaymentMethodValue)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    PaymentMethodValue = c.PaymentMethodValue,
                    Translations = c.PaymentMethodValue.Translations
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new DTO.PaymentMethod()
            {
                Id = c.Id,
                PaymentMethodValue = c.PaymentMethodValue.Translate()
                     
            }).ToList();
            return resultList;
        }

        public virtual async Task<List<PaymentMethodWithPaymentsCount>> GetAllWithPaymentsCountAsync()
        {           
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(p => p.Payments)
                .Include(p =>p.PaymentMethodValue)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    PaymentMethodValue = c.PaymentMethodValue,
                    Translations = c.PaymentMethodValue.Translations,
                    PaymentsCount = c.Payments.Count
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new PaymentMethodWithPaymentsCount()
            {
                Id = c.Id,
                PaymentMethodValue = c.PaymentMethodValue.Translate(),
                PaymentsCount = c.PaymentsCount
                     
            }).ToList();
            return resultList;

        }
        
        public override async Task<DAL.App.DTO.PaymentMethod> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var paymentMethod = await RepositoryDbSet.FindAsync(id);

            if (paymentMethod != null)
            {
                await RepositoryDbContext.Entry(paymentMethod)
                    .Reference(c => c.PaymentMethodValue)
                    .LoadAsync();
                await RepositoryDbContext.Entry(paymentMethod.PaymentMethodValue)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            
            return PaymentMethodMapper.MapFromDomain(paymentMethod);
        }
        
        public override DTO.PaymentMethod Update(DAL.App.DTO.PaymentMethod entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.PaymentMethodValue)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.PaymentMethodValue.SetTranslation(entity.PaymentMethodValue);

            return entity;
        }

    }
}