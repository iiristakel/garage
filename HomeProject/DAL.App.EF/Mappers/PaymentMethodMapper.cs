using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class PaymentMethodMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.PaymentMethod))
            {
                return MapFromDomain((internalDTO.PaymentMethod) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.PaymentMethod))
            {
                return MapFromDAL((externalDTO.PaymentMethod) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.PaymentMethod MapFromDomain(internalDTO.PaymentMethod paymentMethod)
        {
            var res = paymentMethod == null ? null : new externalDTO.PaymentMethod
            {
                Id = paymentMethod.Id,
                PaymentMethodValue = paymentMethod.PaymentMethodValue.Translate()

            };

            return res;
        }

        public static internalDTO.PaymentMethod MapFromDAL(externalDTO.PaymentMethod paymentMethod)
        {
            var res = paymentMethod == null ? null : new internalDTO.PaymentMethod
            {
                Id = paymentMethod.Id,
                PaymentMethodValue = new internalDTO.MultiLangString(paymentMethod.PaymentMethodValue)
            };
            return res;
        }
        
        
        
    }
}