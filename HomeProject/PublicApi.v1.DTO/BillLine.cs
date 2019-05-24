using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class BillLine
    {
        public int Id { get; set; }
        
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public string Product { get; set; }

        public decimal Sum { get; set; }

        public decimal Amount { get; set; }

        public decimal? DiscountPercent { get; set; }

        public decimal? SumWithDiscount { get; set; }
    }
}