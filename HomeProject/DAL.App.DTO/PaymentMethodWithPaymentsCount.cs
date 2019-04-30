using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class PaymentMethodWithPaymentsCount
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string PaymentMethodValue { get; set; }
        public int PaymentsCount { get; set; }
    }
}