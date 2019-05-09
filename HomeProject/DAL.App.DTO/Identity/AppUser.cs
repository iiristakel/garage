using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        

//        public ICollection<AppUserInPosition> Positions { get; set; }
//
//        public ICollection<AppUserOnObject> Objects { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }

        
        public string FirstLastName => FirstName + " " + LastName;
        public ICollection<AppUserInPosition> AppUserInPositions { get; set; }

        
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