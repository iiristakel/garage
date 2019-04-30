using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class Product
    {
        
        public int Id { get; set; }

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