using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class Client
    {
        public int Id { get; set; }

        public int? ClientGroupId { get; set; }
        public ClientGroup ClientGroup { get; set; }


        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string CompanyName { get; set; }

        [MaxLength(120)]
        [MinLength(1)]
        [Required]
        public string Address { get; set; }

        [MaxLength(15)]
        [MinLength(1)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(64)] [MinLength(1)] public string ContactPerson { get; set; }
    }
}