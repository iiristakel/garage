using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO
{
    public class AppUserInPosition
    {
        
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int AppUserPositionId { get; set; }
        public AppUserPosition AppUserPosition { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}