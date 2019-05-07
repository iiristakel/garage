using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class ClientGroupWithClientCount
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public string Name { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public string Description { get; set; }

        [Display(Name = nameof(DiscountPercent), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public decimal DiscountPercent { get; set; }

        [Display(Name = nameof(ClientCount), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public int ClientCount { get; set; }
    }
}