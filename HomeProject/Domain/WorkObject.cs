using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class WorkObject : DomainEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<AppUserOnObject> AppUsersOnObject { get; set; }

        public ICollection<ProductService> ProductsServices { get; set; }
        
        public ICollection<Bill> Bills { get; set; }

        [DataType(DataType.Date)]
        public DateTime? From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}