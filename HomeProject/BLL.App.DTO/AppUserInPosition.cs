using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO
{
    public class AppUserInPosition
    {

        public int Id { get; set; }

        public int AppUserId { get; set; }
        [Display(Name = nameof(AppUser), ResourceType = typeof(Resources.Domain.AppUserInPosition))]
        public AppUser AppUser { get; set; }

        public int AppUserPositionId { get; set; }
        [Display(Name = nameof(AppUserPosition), ResourceType = typeof(Resources.Domain.AppUserInPosition))]
        public AppUserPosition AppUserPosition { get; set; }

        [Display(Name = nameof(From), ResourceType = typeof(Resources.Domain.AppUserInPosition))]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [Display(Name = nameof(Until), ResourceType = typeof(Resources.Domain.AppUserInPosition))]
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}