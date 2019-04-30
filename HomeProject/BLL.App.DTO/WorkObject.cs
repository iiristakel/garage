using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class WorkObject
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

//        public ICollection<AppUserOnObject> AppUsersOnObject { get; set; }

//        public ICollection<ProductForClient> ProductsForClient { get; set; }

        [DataType(DataType.Date)]
        public DateTime? From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}