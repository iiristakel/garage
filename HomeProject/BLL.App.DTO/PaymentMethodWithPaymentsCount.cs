using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class PaymentMethodWithPaymentsCount
    {
        public int Id { get; set; }

        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(PaymentMethodValue), ResourceType = typeof(Resources.Domain.PaymentMethod))]
        public string PaymentMethodValue { get; set; }

        [Display(Name = nameof(PaymentsCount), ResourceType = typeof(Resources.Domain.PaymentMethod))]
        public int PaymentsCount { get; set; }

    }
}