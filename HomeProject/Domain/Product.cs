using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product : DomainEntity
    {
        public ICollection<ProductForClient> ProductForClients { get; set; }

        [MaxLength(256)]
        [MinLength(1)]
        [Required]
        public MultiLangString ProductName { get; set; }
        
        [MaxLength(128)]
        [MinLength(1)]
        public string ProductCode {get;set;}
        
        public decimal? Price { get; set; }
    }
}