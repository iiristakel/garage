using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class ClientGroup
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal DiscountPercent { get; set; }
    }
}