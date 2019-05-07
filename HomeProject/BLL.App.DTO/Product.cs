using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Product
    {
        
        public int Id { get; set; }

        [Display(Name = nameof(ProductName), ResourceType = typeof(Resources.Domain.Product))]
        public string ProductName { get; set; }

        [Display(Name = nameof(ProductCode), ResourceType = typeof(Resources.Domain.Product))]
        public string ProductCode {get;set;}

        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Product))]
        public decimal Price { get; set; }
    }
}