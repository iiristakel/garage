using System;
using System.Collections.Generic;
using Domain;

namespace DAL.App.DTO
{
    public class WorkObjectsDTO
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public ICollection<WorkerOnObject> WorkersOnObject { get; set; }

        public ICollection<ProductForClient> ProductsForClient { get; set; }

        public DateTime From { get; set; }
        
        public DateTime? Until { get; set; }
    }
}