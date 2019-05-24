using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class ProductService
    {
        public int Id { get; set; }
        
        public int ProductForClientId { get; set; }
        
       //TODO: [Display(Name = nameof(ProductForClient), ResourceType = typeof(Resources.Domain.ProductService))]
        public ProductForClient ProductForClient { get; set; }

        public int WorkObjectId { get; set; }
        
        //TODO: [Display(Name = nameof(WorkObject), ResourceType = typeof(Resources.Domain.ProductService))]
        public WorkObject WorkObject { get; set; }

        [MaxLength(1028, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(3, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        //TODO: [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.ProductService))]
        public string Description { get; set; }
    }
}