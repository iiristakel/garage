using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class PaymentMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Payment))
            {
                return MapFromInternal((internalDTO.Payment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Payment))
            {
                return MapFromExternal((externalDTO.Payment) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Payment MapFromInternal(internalDTO.Payment payment)
        {
            var res = payment == null ? null : new externalDTO.Payment
            {
                Id = payment.Id,
                BillId = payment.BillId,
                Bill = BillMapper.MapFromInternal((payment.Bill)),
                PaymentMethodId = payment.PaymentMethodId,
                PaymentMethod = PaymentMethodMapper.MapFromInternal(payment.PaymentMethod),
                ClientId = payment.ClientId,
                Client = ClientMapper.MapFromInternal(payment.Client),
                Sum = payment.Sum,
                PaymentTime = payment.PaymentTime

            };

            return res;
        }

        public static internalDTO.Payment MapFromExternal(externalDTO.Payment payment)
        {
            var res = payment == null ? null : new internalDTO.Payment
            {
                Id = payment.Id,
                BillId = payment.BillId,
                Bill = BillMapper.MapFromExternal(payment.Bill),
                PaymentMethodId = payment.PaymentMethodId,
                PaymentMethod = PaymentMethodMapper.MapFromExternal(payment.PaymentMethod),
                ClientId = payment.ClientId,
                Client = ClientMapper.MapFromExternal(payment.Client),
                Sum = payment.Sum,
                PaymentTime = payment.PaymentTime
            };
            return res;
        }

    }
}