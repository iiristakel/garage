using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class WorkObject
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        [Display(Name = nameof(Client), ResourceType = typeof(Resources.Domain.WorkObject))]
        public Client Client { get; set; }

//        public ICollection<AppUserOnObject> AppUsersOnObject { get; set; }
//
//        public ICollection<ProductForClient> ProductsForClient { get; set; }

        [Display(Name = nameof(From), ResourceType = typeof(Resources.Domain.WorkObject))]
        [DataType(DataType.Date)]
        public DateTime? From { get; set; }

        [Display(Name = nameof(Until), ResourceType = typeof(Resources.Domain.WorkObject))]
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}