namespace DAL.App.DTO
{
    public class ClientGroupWithClientCount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public int ClientCount { get; set; }
    }
}