using System.Collections.Generic;

namespace Domain
{
    public class ProductForClient : DomainEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int? WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public ICollection<BillLine> BillLines { get; set; }

        public decimal Count { get; set; }
    }
}