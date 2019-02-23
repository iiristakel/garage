using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ClientGroup : BaseEntity
    {
        public ICollection<Client> Clients { get; set; }


        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int DiscountPercent { get; set; }

        
    }
}