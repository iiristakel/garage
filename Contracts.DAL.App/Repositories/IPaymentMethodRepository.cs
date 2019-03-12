using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IPaymentMethodRepository : IBaseRepositoryAsync<PaymentMethod>
    {
        //add here custom methods
    }
}