using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class BillLineMapper : IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.BillLine))
            {
                return MapFromDomain((internalDTO.BillLine) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.BillLine))
            {
                return MapFromDAL((externalDTO.BillLine) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.BillLine MapFromDomain(internalDTO.BillLine billLine)
        {
            var res = billLine == null ? null : new externalDTO.BillLine
            {
                Id = billLine.Id,
                BillId = billLine.BillId,
                Bill = BillMapper.MapFromDomain(billLine.Bill),
                Product = billLine.Product,
                Amount = billLine.Amount,
                Sum = billLine.Sum,
                DiscountPercent = billLine.DiscountPercent,
                SumWithDiscount = billLine.SumWithDiscount

            };

            return res;
        }

        public static internalDTO.BillLine MapFromDAL(externalDTO.BillLine billLine)
        {
            var res = billLine == null ? null : new internalDTO.BillLine
            {
                Id = billLine.Id,
                BillId = billLine.BillId,
                Bill = BillMapper.MapFromDAL(billLine.Bill),
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