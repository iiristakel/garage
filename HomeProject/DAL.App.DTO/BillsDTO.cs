using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAL.App.DTO
{
    public class BillsDTO
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public string InvoiceNr { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public ICollection<BillLine> BillLines { get; set; }

        public int PaymentsCount { get; set; }

        public decimal ArrivalFee { get; set; }
        public decimal SumWithoutTaxes { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? FinalSum { get; set; }
        
        public string Comment { get; set; }
    }
}