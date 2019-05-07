using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class AppUserPosition
    {
        public int Id { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string AppUserPositionValue { get; set; }
    }
}