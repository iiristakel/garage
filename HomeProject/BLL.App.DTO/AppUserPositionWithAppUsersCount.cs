using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class AppUserPositionWithAppUsersCount
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string AppUserPositionValue { get; set; }

        public int AppUsersCount { get; set; }
        
        
    }
    
}