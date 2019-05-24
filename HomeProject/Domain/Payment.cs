using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Payment : DomainEntity
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public decimal Sum { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PaymentTime { get; set; }
    }
}