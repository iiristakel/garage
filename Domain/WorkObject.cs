using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class WorkObject : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<WorkerOnObject> WorkersOnObject { get; set; }

        public ICollection<ProductForClient> ProductsForClient { get; set; }

        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}