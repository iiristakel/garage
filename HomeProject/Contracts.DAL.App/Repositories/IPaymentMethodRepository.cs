using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPaymentMethodRepository : IPaymentMethodRepository<DALAppDTO.PaymentMethod>
    {
        Task<List<DALAppDTO.PaymentMethodWithPaymentsCount>> GetAllWithPaymentsCountAsync();
    }

    public interface IPaymentMethodRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
    }
}