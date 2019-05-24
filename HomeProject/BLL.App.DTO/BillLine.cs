using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class BillLine
    {
        public int Id { get; set; }
        
        public int BillId { get; set; }
        [Display(Name = nameof(Bill), ResourceType = typeof(Resources.Domain.BillLine))]
        public Bill Bill { get; set; }

        [MaxLength(256, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Product), ResourceType = typeof(Resources.Domain.BillLine))]
        public string Product { get; set; }

        [Display(Name = nameof(Sum), ResourceType = typeof(Resources.Domain.BillLine))]
        public decimal Sum { get; set; }

        [Display(Name = nameof(Amount), ResourceType = typeof(Resources.Domain.BillLine))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(DiscountPercent), ResourceType = typeof(Resources.Domain.BillLine))]
        public decimal? DiscountPercent { get; set; }

        [Display(Name = nameof(SumWithDiscount), ResourceType = typeof(Resources.Domain.BillLine))]
        public decimal? SumWithDiscount { get; set; }
    }
}