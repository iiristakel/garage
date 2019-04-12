using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace DAL.App.DTO
{
    public class ClientsDTO
    {
        public int Id { get; set; }

        public ClientGroup ClientGroup { get; set; }

        public int ProductsCount { get; set; }
        
        public string CompanyName { get; set; }
        
        public string Address { get; set; }
        
        public string Phone { get; set; }
        
        public string ContactPerson { get; set; }
    }
}