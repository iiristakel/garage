using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.DTO
{
    public class PaymentService  : BaseEntityService<Payment, IAppUnitOfWork>, IPaymentService
    {
        public PaymentService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }
}