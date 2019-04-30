using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
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