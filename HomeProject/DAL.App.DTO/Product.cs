using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class Product
    {
        
        public int Id { get; set; }

        [MaxLength(256)]
        [MinLength(1)]
        [Required]
        public string ProductName { get; set; }
        
        [MaxLength(128)]
        [MinLength(1)]
        public string ProductCode {get;set;}
        
        public decimal? Price { get; set; }
    }
}