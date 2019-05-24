using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Product
    {
        
        public int Id { get; set; }

        [MaxLength(256, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(ProductName), ResourceType = typeof(Resources.Domain.Product))]
        public string ProductName { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(ProductCode), ResourceType = typeof(Resources.Domain.Product))]
        public string ProductCode {get;set;}

        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Product))]
        public decimal? Price { get; set; }
    }
}