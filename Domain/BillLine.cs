namespace Domain
{
    public class BillLine : BaseEntity
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        
        public int ProductForObjectId { get; set; }
        public ProductForClient ProductForObject { get; set; }

        public int Sum { get; set; }
        public int Amount { get; set; } 
        public int? DiscountPercent { get; set; }
    }
}