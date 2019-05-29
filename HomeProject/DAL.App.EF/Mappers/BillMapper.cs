using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class BillMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Bill))
            {
                return MapFromDomain((internalDTO.Bill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Bill))
            {
                return MapFromDAL((externalDTO.Bill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Bill MapFromDomain(internalDTO.Bill bill)
        {
            var res = bill == null ? null : new externalDTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
                Client = ClientMapper.MapFromDomain(bill.Client),
                ArrivalFee = bill.ArrivalFee,
                SumWithoutTaxes = bill.SumWithOutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = bill.Comment.Translate(),
                WorkObjectId = bill.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromDomain(bill.WorkObject)

            };

            return res;
        }

        public static internalDTO.Bill MapFromDAL(externalDTO.Bill bill)
        {
            var res = bill == null ? null : new internalDTO.Bill
            {
                Id = bill.Id,
                ClientId = bill.ClientId,
                Client = ClientMapper.MapFromDAL(bill.Client),
                WorkObjectId = bill.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromDAL(bill.WorkObject),
                ArrivalFee = bill.ArrivalFee,
                SumWithOutTaxes = bill.SumWithoutTaxes,
                TaxPercent = bill.TaxPercent,
                FinalSum = bill.FinalSum,
                DateTime = bill.DateTime,
                InvoiceNr = bill.InvoiceNr,
                Comment = new internalDTO.MultiLangString(bill.Comment)
            };
            return res;
        }

    }
}