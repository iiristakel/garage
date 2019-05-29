using System;
using System.Linq;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class BillMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Bill))
            {
                return MapFromInternal((internalDTO.Bill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Bill))
            {
                return MapFromExternal((externalDTO.Bill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Bill MapFromInternal(internalDTO.Bill bill)
        {
            var res = bill == null ? null : new externalDTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
                Client = ClientMapper.MapFromInternal(bill.Client),
                ArrivalFee = bill.ArrivalFee,
                SumWithoutTaxes = bill.SumWithoutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = bill.Comment,
                WorkObjectId = bill.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromInternal(bill.WorkObject),
//                BillLines = bill.BillLines.Select(e => BillLineMapper.MapFromInternal(e)).ToList(),                


            };

            return res;
        }

        public static internalDTO.Bill MapFromExternal(externalDTO.Bill bill)
        {
            var res = bill == null ? null : new internalDTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
                Client = ClientMapper.MapFromExternal(bill.Client),
                ArrivalFee = bill.ArrivalFee,
                SumWithoutTaxes = bill.SumWithoutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = bill.Comment,
                WorkObjectId = bill.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromExternal(bill.WorkObject),
//                BillLines = bill.BillLines.Select(e => BillLineMapper.MapFromExternal(e)).ToList(),                

            };
            return res;
        }

        
    }
}