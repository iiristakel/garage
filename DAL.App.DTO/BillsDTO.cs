using System;
using System.Collections.Generic;
using Domain;

namespace DAL.App.DTO
{
    public class BillsDTO
    {
        public int Id { get; set; }

        public string InvoiceNr { get; set; }

        public Client Client { get; set; }
        
        public DateTime DateTime { get; set; }

        public ICollection<BillLine> BillLines { get; set; }

        public int PaymentsCount { get; set; }

        public decimal ArrivalFee { get; set; }
        public decimal SumWithoutTaxes { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal FinalSum { get; set; }
        


        public string Comment { get; set; }
    }
}