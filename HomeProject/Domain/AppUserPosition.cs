using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class AppUserPosition : BaseEntity
    {
        public ICollection<AppUserInPosition> AppUsers { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string PositionValue { get; set; }
    }
}