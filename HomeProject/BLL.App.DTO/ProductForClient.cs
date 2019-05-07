using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class ProductForClient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [Display(Name = nameof(Product), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public Product Product { get; set; }

        public int? WorkObjectId { get; set; }
        [Display(Name = nameof(WorkObject), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public WorkObject WorkObject { get; set; }

        public int ClientId { get; set; }
        [Display(Name = nameof(Client), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public Client Client { get; set; }

        [Display(Name = nameof(Count), ResourceType = typeof(Resources.Domain.ProductForClient))]
        public decimal Count { get; set; }
    }
}