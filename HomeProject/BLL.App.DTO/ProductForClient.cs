
namespace BLL.App.DTO
{
    public class ProductForClient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int? WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public decimal Count { get; set; }
    }
}