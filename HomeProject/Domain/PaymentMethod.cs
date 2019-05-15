using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PaymentMethod : DomainEntity
    {
        public ICollection<Payment> Payments { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public MultiLangString PaymentMethodValue { get; set; }
    }
}