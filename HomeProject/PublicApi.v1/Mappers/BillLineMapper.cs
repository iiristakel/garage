using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class BillLineMapper 
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.BillLine))
            {
                return MapFromInternal((internalDTO.BillLine) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.BillLine))
            {
                return MapFromExternal((externalDTO.BillLine) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.BillLine MapFromInternal(internalDTO.BillLine billLine)
        {
            var res = billLine == null ? null : new externalDTO.BillLine
            {
                Id = billLine.Id,
                BillId = billLine.BillId,
                Bill = BillMapper.MapFromInternal(billLine.Bill),
                Product = billLine.Product,
                Amount = billLine.Amount,
                Sum = billLine.Sum,
                DiscountPercent = billLine.DiscountPercent,
                SumWithDiscount = billLine.SumWithDiscount

            };

            return res;
        }

        public static internalDTO.BillLine MapFromExternal(externalDTO.BillLine billLine)
        {
            var res = billLine == null ? null : new internalDTO.BillLine
            {
                Id = billLine.Id,
                BillId = billLine.BillId,
                Bill = BillMapper.MapFromExternal(billLine.Bill),
                Product = billLine.Product,
                Amount = billLine.Amount,
                Sum = billLine.Sum,
                DiscountPercent = billLine.DiscountPercent,
                SumWithDiscount = billLine.SumWithDiscount
            };
            return res;
        }

    }
}