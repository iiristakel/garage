using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BillLine : BaseEntity
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        
        public int ProductForClientId { get; set; }
        public ProductForClient ProductForClient { get; set; }

        public decimal Sum { get; set; }
        public decimal Amount { get; set; } 
        public decimal? DiscountPercent { get; set; }
        public decimal? SumWithDiscount { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal FinalSum { get; set; }
        
    }
}