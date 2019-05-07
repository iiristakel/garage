using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class Product
    {
        
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductCode {get;set;}

        public decimal Price { get; set; }
    }
}