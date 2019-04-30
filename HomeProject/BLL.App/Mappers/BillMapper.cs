using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BillMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Bill))
            {
                return MapFromDAL((DAL.App.DTO.Bill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Bill))
            {
                return MapFromBLL((BLL.App.DTO.Bill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Bill MapFromDAL(DAL.App.DTO.Bill bill)
        {
            var res = bill == null ? null : new BLL.App.DTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
                Client = ClientMapper.MapFromDAL(bill.Client),
                ArrivalFee = bill.ArrivalFee,
                SumWithoutTaxes = bill.SumWithoutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = bill.Comment

            };

            return res;
        }

        public static DAL.App.DTO.Bill MapFromBLL(BLL.App.DTO.Bill bill)
        {
            var res = bill == null ? null : new DAL.App.DTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
                Client = ClientMapper.MapFromBLL(bill.Client),
                ArrivalFee = bill.ArrivalFee,
                SumWithoutTaxes = bill.SumWithoutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = bill.Comment
            };
            return res;
        }

        public static BLL.App.DTO.BillWithPaymentsCount MapFromDAL(DAL.App.DTO.BillWithPaymentsCount billWithPaymentsCount)
        {
            var res = billWithPaymentsCount == null ? null : new BLL.App.DTO.BillWithPaymentsCount()
            {
                Id = billWithPaymentsCount.Id,
                ClientId = billWithPaymentsCount.ClientId,
                Client = ClientMapper.MapFromDAL(billWithPaymentsCount.Client),
                ArrivalFee = billWithPaymentsCount.ArrivalFee,
                SumWithoutTaxes = billWithPaymentsCount.SumWithoutTaxes,
                TaxPercent = billWithPaymentsCount.TaxPercent,
                FinalSum = billWithPaymentsCount.FinalSum,
                DateTime = billWithPaymentsCount.DateTime,
                InvoiceNr = billWithPaymentsCount.InvoiceNr,
                PaymentsCount = billWithPaymentsCount.PaymentsCount,
                Comment = billWithPaymentsCount.Comment

            };

            return res;
        }
    }
}