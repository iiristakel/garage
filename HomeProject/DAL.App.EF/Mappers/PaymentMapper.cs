using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class PaymentMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Payment))
            {
                return MapFromDomain((internalDTO.Payment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Payment))
            {
                return MapFromDAL((externalDTO.Payment) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Payment MapFromDomain(internalDTO.Payment payment)
        {
            var res = payment == null ? null : new externalDTO.Payment
            {
                Id = payment.Id,
                BillId = payment.BillId,
                Bill = DAL.App.EF.Mappers.BillMapper.MapFromDomain(payment.Bill),
                PaymentMethodId = payment.PaymentMethodId,
                PaymentMethod = PaymentMethodMapper.MapFromDomain(payment.PaymentMethod),
                ClientId = payment.ClientId,
                Client = DAL.App.EF.Mappers.ClientMapper.MapFromDomain(payment.Client),
                Sum = payment.Sum,
                PaymentTime = payment.PaymentTime

            };

            return res;
        }

        public static internalDTO.Payment MapFromDAL(externalDTO.Payment payment)
        {
            var res = payment == null ? null : new internalDTO.Payment
            {
                Id = payment.Id,
                BillId = payment.BillId,
                Bill = DAL.App.EF.Mappers.BillMapper.MapFromDAL(payment.Bill),
                PaymentMethodId = payment.PaymentMethodId,
                PaymentMethod = PaymentMethodMapper.MapFromDAL(payment.PaymentMethod),
                ClientId = payment.ClientId,
                Client = DAL.App.EF.Mappers.ClientMapper.MapFromDAL(payment.Client),
                Sum = payment.Sum,
                PaymentTime = payment.PaymentTime
            };
            return res;
        }

    }
}