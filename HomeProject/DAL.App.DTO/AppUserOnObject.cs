using System;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class AppUserOnObject
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        [DataType(DataType.Date)]

        public DateTime? From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}