
using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class BillLine
    {
        public int Id { get; set; }
        
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        public string Product { get; set; }

        public decimal Sum { get; set; }
        public decimal Amount { get; set; } 
        public decimal? DiscountPercent { get; set; }
        public decimal? SumWithDiscount { get; set; }
    }
}