namespace DAL.App.DTO
{
    public class BillLineDTO
    {
        public int Id { get; set; }
        
        public string Product { get; set; }

        public decimal Sum { get; set; }
        public decimal Amount { get; set; } 
        public decimal? DiscountPercent { get; set; }
        public decimal? SumWithDiscount { get; set; }
    }
}