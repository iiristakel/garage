using System.Collections.Generic;

namespace Domain
{
    public class ProductForClient : DomainEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<ProductService> ProductServices { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public decimal Count { get; set; }
    }
}