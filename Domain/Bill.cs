using System;
using System.Collections.Generic;

namespace Domain
{
    public class Bill : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<BillLine> BillLines { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public DateTime DateTime { get; set; }
        public int Sum { get; set; }
        public int? DiscountPercent { get; set; }
        public int? TaxPercent { get; set; }
    }
}