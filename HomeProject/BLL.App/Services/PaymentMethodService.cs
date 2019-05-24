using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

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

        
    }
}