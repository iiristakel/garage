using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class BillWithPaymentsCount 
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public string InvoiceNr { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

//        public ICollection<BillLine> BillLines { get; set; }

        public int PaymentsCount { get; set; }

        public decimal ArrivalFee { get; set; }
        public decimal SumWithoutTaxes { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? FinalSum { get; set; }
        
        public string Comment { get; set; }
    }
}