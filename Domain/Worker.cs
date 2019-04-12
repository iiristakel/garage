using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class Worker : BaseEntity
    {
        public ICollection<WorkerInPosition> WorkerInPositions { get; set; }

        public ICollection<WorkerOnObject> WorkerOnTasks { get; set; }

        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }
        
        public string FirstLastName => FirstName + " " + LastName;
        public string LastFirstName => LastName + " " + FirstName;

        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        
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