using System;
using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class AppUserOnObject : DomainEntity
    {
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