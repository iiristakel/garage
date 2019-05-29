using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class ProductForClient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [Display(Name = nameof(Product), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public Product Product { get; set; }

        public ICollection<ProductService> ProductServices { get; set; }

        public int ClientId { get; set; }
        [Display(Name = nameof(Client), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public Client Client { get; set; }

        [Display(Name = nameof(Count), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public decimal Count { get; set; }

    }
}