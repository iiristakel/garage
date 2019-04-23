using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace DAL.App.DTO
{
    public class WorkObjectsDTO
    {
        public int Id { get; set; }
        
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