using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class ProductForClient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public ICollection<ProductService> ProductServices { get; set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }

        public decimal Count { get; set; }
    }
}