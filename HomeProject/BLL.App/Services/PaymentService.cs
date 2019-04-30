using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Payment = BLL.App.DTO.Payment;

namespace BLL.App.Services
{
    public class PaymentService  
        : BaseEntityService<BLL.App.DTO.Payment, DAL.App.DTO.Payment,
            IAppUnitOfWork>, IPaymentService
    {
        public PaymentService(IAppUnitOfWork uow) : base(uow, new PaymentMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Payment, Domain.Payment>();

        }

        public async Task<List<Payment>> AllForUserAsync(int userId)
        {
            return (await Uow.Payments
                    .AllForUserAsync(userId))
                .Select(e => PaymentMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<Payment> FindForUserAsync(int id, int userId)
        {
            return PaymentMapper.MapFromDAL( await Uow.Payments.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Payments.BelongsToUserAsync(id, userId);
        }
    }
}