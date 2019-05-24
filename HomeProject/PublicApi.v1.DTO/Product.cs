using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
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
        [Required]
        public string ProductCode {get;set;}

        public decimal? Price { get; set; }
    }
}