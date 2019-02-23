using System;
using System.Collections.Generic;

namespace Domain
{
    public class WorkObject : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<WorkerOnObject> WorkersOnObject { get; set; }

        public ICollection<ProductForClient> ProductsForObject { get; set; }

        public DateTime From { get; set; }
        public DateTime? Until { get; set; }
    }
}