using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductService : DomainEntity
    {
        public int ProductForClientId { get; set; }
        public ProductForClient ProductForClient { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        [MinLength(3)]
        [MaxLength(1028)]
        [Required]
        public MultiLangString Description { get; set; }
    }
}