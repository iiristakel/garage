using System;

namespace Domain
{
    public class Payment : BaseEntity
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public DateTime PaymentTime { get; set; }
    }
}