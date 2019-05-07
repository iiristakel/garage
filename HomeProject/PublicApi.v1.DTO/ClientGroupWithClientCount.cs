using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class ClientGroupWithClientCount
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal DiscountPercent { get; set; }

        public int ClientCount { get; set; }
    }
}