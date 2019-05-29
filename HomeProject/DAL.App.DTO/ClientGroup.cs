using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class ClientGroup
    {
        public int Id { get; set; }
        
        [MaxLength(128)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal? DiscountPercent { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}