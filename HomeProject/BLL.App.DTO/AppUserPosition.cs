using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class AppUserPosition
    {
        public int Id { get; set; }

        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(AppUserPositionValue), ResourceType = typeof(Resources.Domain.AppUserPosition))]
        public string AppUserPositionValue { get; set; }
    }
}