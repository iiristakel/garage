using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Client : DomainEntity
    {
        public int? ClientGroupId { get; set; }
        public ClientGroup ClientGroup { get; set; }

        public ICollection<Bill> Bills { get; set; }

        public ICollection<WorkObject> WorkObjects { get; set; }

        public ICollection<ProductForClient> ProductsForClient { get; set; }

        
        [MaxLength(128)]
        [MinLength(1)]
        public string CompanyName { get; set; }
        
        [MaxLength(256)]
        [MinLength(1)]
        [Required]
        public string Address { get; set; }
        
        [MaxLength(15)]
        [MinLength(1)]
        [Required]
        public string Phone { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string ContactPerson { get; set; }

        [DataType(DataType.Date)]
        public DateTime? From { get; set; }
        
    }
}