using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PaymentMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Payment))
            {
                return MapFromDAL((DAL.App.DTO.Payment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Payment))
            {
                return MapFromBLL((BLL.App.DTO.Payment) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Payment MapFromDAL(DAL.App.DTO.Payment payment)
        {
            var res = payment == null ? null : new BLL.App.DTO.Payment
            {
                Id = payment.Id,
                BillId = payment.BillId,
                Bill = BillMapper.MapFromDAL(payment.Bill),
                PaymentMethodId = payment.PaymentMethodId,
                PaymentMethod = PaymentMethodMapper.MapFromDAL(payment.PaymentMethod),
                ClientId = payment.ClientId,
                Client = ClientMapper.MapFromDAL(payment.Client),
                Sum = payment.Sum,
                PaymentTime = payment.PaymentTime

            };

            return res;
        }

        public static DAL.App.DTO.Payment MapFromBLL(BLL.App.DTO.Payment payment)
        {
            var res = payment == null ? null : new DAL.App.DTO.Payment
            {
                Id = payment.Id,
                BillId = payment.BillId,
                Bill = BillMapper.MapFromBLL(payment.Bill),
                PaymentMethodId = payment.PaymentMethodId,
                PaymentMethod = PaymentMethodMapper.MapFromBLL(payment.PaymentMethod),
                ClientId = payment.ClientId,
                Client = ClientMapper.MapFromBLL(payment.Client),
                Sum = payment.Sum,
                PaymentTime = payment.PaymentTime
            };
            return res;
        }

    }
}