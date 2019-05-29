using System;
using System.Linq;
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
                Comment = bill.Comment,
                WorkObjectId = bill.WorkObjectId,
//                BillLines = bill.BillLines.Select(e => BillLineMapper.MapFromDAL(e)).ToList(),
//                Payments = bill.Payments.Select(e => PaymentMapper.MapFromDAL(e)).ToList(),
                WorkObject = WorkObjectMapper.MapFromDAL(bill.WorkObject)

            };

            return res;
        }

        public static DAL.App.DTO.Bill MapFromBLL(BLL.App.DTO.Bill bill)
        {
            var res = bill == null ? null : new DAL.App.DTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
//                Client = ClientMapper.MapFromBLL(bill.Client),
                ArrivalFee = bill.ArrivalFee,
                SumWithoutTaxes = bill.SumWithoutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = bill.Comment,
                WorkObjectId = bill.WorkObjectId,
                BillLines = bill.BillLines.Select(e => BillLineMapper.MapFromBLL(e)).ToList(),
                Payments = bill.Payments.Select(e => PaymentMapper.MapFromBLL(e)).ToList(),
//                WorkObject = WorkObjectMapper.MapFromBLL(bill.WorkObject)
            };
            return res;
        }

        
    }
}