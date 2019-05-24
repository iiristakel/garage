using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ClientGroup : DomainEntity
    {
        public ICollection<Client> Clients { get; set; }

        [MaxLength(128)]
        [MinLength(1)]
        [Required]
        public MultiLangString Name { get; set; }
        
        public MultiLangString Description { get; set; }
        
        public decimal? DiscountPercent { get; set; }

        
    }
}