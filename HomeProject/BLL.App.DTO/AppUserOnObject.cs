using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO
{
    public class AppUserOnObject
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        [Display(Name = nameof(AppUser), ResourceType = typeof(Resources.Domain.AppUserOnObject))]
        public AppUser AppUser { get; set; }

        public int WorkObjectId { get; set; }
        [Display(Name = nameof(WorkObject), ResourceType = typeof(Resources.Domain.AppUserOnObject))]
        public WorkObject WorkObject { get; set; }

        [Display(Name = nameof(From), ResourceType = typeof(Resources.Domain.AppUserOnObject))]
        [DataType(DataType.Date)]
        public DateTime? From { get; set; }

        [Display(Name = nameof(Until), ResourceType = typeof(Resources.Domain.AppUserOnObject))]
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}