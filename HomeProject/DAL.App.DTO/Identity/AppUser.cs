using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        

        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }


        public string FirstLastName { get; set; }
        
        public ICollection<AppUserInPosition> AppUserInPositions { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime? HiringDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? LeftJob { get; set; }
        
        public string PhoneNr { get; set; }

        public string Email { get; set; }


    }
}