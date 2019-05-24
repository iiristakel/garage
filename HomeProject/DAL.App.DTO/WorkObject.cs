using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace DAL.App.DTO
{
    public class WorkObject
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<AppUserOnObject> AppUsersOnObject { get; set; }

        public ICollection<Domain.ProductService> ProductsServices { get; set; }
        
        public ICollection<Bill> Bills { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}