using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BillLine : BaseEntity
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string Product { get; set; }

        public decimal Sum { get; set; }
        public decimal Amount { get; set; } 
        public decimal? DiscountPercent { get; set; }
        public decimal? SumWithDiscount { get; set; }
        
    }
}