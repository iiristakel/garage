using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class PaymentMethodMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.PaymentMethod))
            {
                return MapFromInternal((internalDTO.PaymentMethod) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.PaymentMethod))
            {
                return MapFromExternal((externalDTO.PaymentMethod) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.PaymentMethod MapFromInternal(internalDTO.PaymentMethod paymentMethod)
        {
            var res = paymentMethod == null ? null : new externalDTO.PaymentMethod
            {
                Id = paymentMethod.Id,
                PaymentMethodValue = paymentMethod.PaymentMethodValue

            };

            return res;
        }

        public static internalDTO.PaymentMethod MapFromExternal(externalDTO.PaymentMethod paymentMethod)
        {
            var res = paymentMethod == null ? null : new internalDTO.PaymentMethod
            {
                Id = paymentMethod.Id,
                PaymentMethodValue = paymentMethod.PaymentMethodValue
            };
            return res;
        }
        
       
        
    }
}