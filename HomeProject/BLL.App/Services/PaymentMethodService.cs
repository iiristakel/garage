using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using PaymentMethodWithPaymentsCount = BLL.App.DTO.PaymentMethodWithPaymentsCount;

namespace BLL.App.Services
{
    public class PaymentMethodService 
        : BaseEntityService<BLL.App.DTO.PaymentMethod, DAL.App.DTO.PaymentMethod,
            IAppUnitOfWork>, IPaymentMethodService
    {
        public PaymentMethodService(IAppUnitOfWork uow) : base(uow, new PaymentMethodMapper())
        {
            ServiceRepository = Uow.PaymentMethods;
        }

        public async Task<List<PaymentMethodWithPaymentsCount>> GetAllWithPaymentsCountAsync()
        {
            return (await Uow.PaymentMethods.GetAllWithPaymentsCountAsync())
                .Select(e => PaymentMethodMapper.MapFromDAL(e))
                .ToList();

        }
    }
}