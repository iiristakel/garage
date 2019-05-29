using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Client
    {
        public int Id { get; set; }
        
        public int? ClientGroupId { get; set; }
        [Display(Name = nameof(ClientGroup), ResourceType = typeof(Resources.Domain.Client))]
        public ClientGroup ClientGroup { get; set; }

        public ICollection<Bill> Bills { get; set; }
        public ICollection<ProductForClient> ProductsForClient { get; set; }


        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(CompanyName), ResourceType = typeof(Resources.Domain.Client))]
        public string CompanyName { get; set; }

        [MaxLength(120, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Address), ResourceType = typeof(Resources.Domain.Client))]
        public string Address { get; set; }

        [MaxLength(15, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Phone), ResourceType = typeof(Resources.Domain.Client))]
        public string Phone { get; set; }

        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(ContactPerson), ResourceType = typeof(Resources.Domain.Client))]
        public string ContactPerson { get; set; }
        
        //TODO: [Display(Name = nameof(From), ResourceType = typeof(Resources.Domain.Client))]
        [DataType(DataType.Date)]
        public DateTime? From { get; set; }
        
        public string CompanyAndAddress { get; set; }

    }
}