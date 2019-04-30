namespace BLL.App.DTO
{
    public class PaymentMethodWithPaymentsCount
    {
        public int Id { get; set; }
        public string PaymentMethodValue { get; set; }
        public int PaymentsCount { get; set; }
    }
}