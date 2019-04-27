using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<int>, IBaseEntity
// PK type is int
    {
//        public ICollection<Worker> Workers { get; set; }

        public ICollection<AppUserInPosition> Positions { get; set; }

        public ICollection<AppUserOnObject> Objects { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }

        
        public string FirstLastName => FirstName + " " + LastName;

        [DataType(DataType.Date)]
        public DateTime? HiringDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? LeftJob { get; set; }

        [MaxLength(15)]
        [MinLength(1)]
        public string PhoneNr { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string Email { get; set; }
    }
}