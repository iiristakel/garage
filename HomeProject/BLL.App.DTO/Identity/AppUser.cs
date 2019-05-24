using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }


        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.AppUser))]
        public string FirstName { get; set; }

        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.AppUser))]
        public string LastName { get; set; }


        public string FirstLastName { get; set; }
        
        public ICollection<AppUserInPosition> AppUserInPositions { get; set; }

        [Display(Name = nameof(HiringDate), ResourceType = typeof(Resources.Domain.AppUser))]
        [DataType(DataType.Date)]
        public DateTime? HiringDate { get; set; }

        [Display(Name = nameof(LeftJob), ResourceType = typeof(Resources.Domain.AppUser))]
        [DataType(DataType.Date)]
        public DateTime? LeftJob { get; set; }
        
        [Display(Name = nameof(PhoneNr), ResourceType = typeof(Resources.Domain.AppUser))]
        public string PhoneNr { get; set; }

        [Display(Name = nameof(Email), ResourceType = typeof(Resources.Domain.AppUser))]
        public string Email { get; set; }

    }
}