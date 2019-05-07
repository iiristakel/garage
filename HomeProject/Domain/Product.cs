using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product : DomainEntity
    {
        public ICollection<ProductForClient> ProductsForClients { get; set; }

        [MaxLength(150)]
        [MinLength(1)]
        [Required]
        public string ProductName { get; set; }
        
        [MaxLength(100)]
        [MinLength(1)]
        public string ProductCode {get;set;}
        
        public decimal Price { get; set; }
    }
}