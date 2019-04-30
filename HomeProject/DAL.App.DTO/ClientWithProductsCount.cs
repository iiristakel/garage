using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class ClientWithProductsCount
    {
        public int Id { get; set; }
        
        public int? ClientGroupId { get; set; }
        public ClientGroup ClientGroup { get; set; }

//        public ICollection<ProductForClient> ProductsForClient { get; set; }

        public int ProductsCount { get; set; }
        
        public string CompanyName { get; set; }
        
        public string Address { get; set; }
        
        public string Phone { get; set; }
        
        public string ContactPerson { get; set; }
    }
}