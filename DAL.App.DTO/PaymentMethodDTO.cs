namespace DAL.App.DTO
{
    public class PaymentMethodDTO
    {
        public int Id { get; set; }
        public string PaymentMethodValue { get; set; }
        public int PaymentsCount { get; set; }
    }
}