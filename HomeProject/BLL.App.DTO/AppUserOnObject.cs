using System;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO
{
    public class AppUserOnObject
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Until { get; set; }
    }
}