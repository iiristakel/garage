using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class Bill
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int WorkObjectId { get; set; }

        public WorkObject WorkObject { get; set; }
        
//        public ICollection<BillLine> BillLines { get; set; }
//
//        public ICollection<Payment> Payments { get; set; }
        

        public decimal ArrivalFee { get; set; }
        public decimal? SumWithoutTaxes { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? FinalSum { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [MinLength(1)]
        [MaxLength(64)]
        [Required]
        public string InvoiceNr { get; set; }

        public string Comment { get; set; }
    }
}