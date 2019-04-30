using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BillLineMapper : IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.BillLine))
            {
                return MapFromDAL((DAL.App.DTO.BillLine) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.BillLine))
            {
                return MapFromBLL((BLL.App.DTO.BillLine) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.BillLine MapFromDAL(DAL.App.DTO.BillLine billLine)
        {
            var res = billLine == null ? null : new BLL.App.DTO.BillLine
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

        public static DAL.App.DTO.BillLine MapFromBLL(BLL.App.DTO.BillLine billLine)
        {
            var res = billLine == null ? null : new DAL.App.DTO.BillLine
            {
                Id = billLine.Id,
                BillId = billLine.BillId,
                Bill = BillMapper.MapFromBLL(billLine.Bill),
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