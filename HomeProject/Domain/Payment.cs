using System;

namespace Domain
{
    public class Payment : BaseEntity
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public decimal Sum { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}