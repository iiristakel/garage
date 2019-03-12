using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Bill : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<BillLine> BillLines { get; set; }

        public ICollection<Payment> Payments { get; set; }
        
        public decimal Sum { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? SumWithDiscount { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal FinalSum { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [MinLength(1)]
        [MaxLength(64)]
        [Required]
        public string InvoiceNr { get; set; }

        public string Comment { get; set; }
    }
}