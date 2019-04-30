using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PaymentMethodMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.PaymentMethod))
            {
                return MapFromDAL((DAL.App.DTO.PaymentMethod) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.PaymentMethod))
            {
                return MapFromBLL((BLL.App.DTO.PaymentMethod) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.PaymentMethod MapFromDAL(DAL.App.DTO.PaymentMethod paymentMethod)
        {
            var res = paymentMethod == null ? null : new BLL.App.DTO.PaymentMethod
            {
                Id = paymentMethod.Id,
                PaymentMethodValue = paymentMethod.PaymentMethodValue

            };

            return res;
        }

        public static DAL.App.DTO.PaymentMethod MapFromBLL(BLL.App.DTO.PaymentMethod paymentMethod)
        {
            var res = paymentMethod == null ? null : new DAL.App.DTO.PaymentMethod
            {
                Id = paymentMethod.Id,
                PaymentMethodValue = paymentMethod.PaymentMethodValue
            };
            return res;
        }
        
        public static BLL.App.DTO.PaymentMethodWithPaymentsCount MapFromDAL(DAL.App.DTO.PaymentMethodWithPaymentsCount paymentMethodWithPaymentsCount)
        {
            var res = paymentMethodWithPaymentsCount == null ? null : new BLL.App.DTO.PaymentMethodWithPaymentsCount()
            {
                Id = paymentMethodWithPaymentsCount.Id,
                PaymentMethodValue = paymentMethodWithPaymentsCount.PaymentMethodValue,
                PaymentsCount = paymentMethodWithPaymentsCount.PaymentsCount

            };

            return res;
        }
        
    }
}