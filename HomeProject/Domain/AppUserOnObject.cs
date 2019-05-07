using System;
using Domain.Identity;

namespace Domain
{
    public class AppUserOnObject : DomainEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Until { get; set; }
    }
}