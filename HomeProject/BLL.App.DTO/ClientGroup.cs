using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class ClientGroup
    {
        public int Id { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public string Name { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public string Description { get; set; }

        [Display(Name = nameof(DiscountPercent), ResourceType = typeof(Resources.Domain.ClientGroup))]
        public decimal? DiscountPercent { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}