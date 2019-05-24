using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class ProductService
    {
        public int Id { get; set; }
        
        public int ProductForClientId { get; set; }
        public ProductForClient ProductForClient { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        [MinLength(3)]
        [MaxLength(1028)]
        [Required]
        public string Description { get; set; }
    }
}