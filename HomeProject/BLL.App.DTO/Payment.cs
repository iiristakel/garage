using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Payment
    {
        public int Id { get; set; }
        
        public int BillId { get; set; }
        [Display(Name = nameof(Bill), ResourceType = typeof(Resources.Domain.Payment))]
        public Bill Bill { get; set; }

        public int PaymentMethodId { get; set; }
        [Display(Name = nameof(PaymentMethod), ResourceType = typeof(Resources.Domain.Payment))]
        public PaymentMethod PaymentMethod { get; set; }

        public int ClientId { get; set; }
        [Display(Name = nameof(Client), ResourceType = typeof(Resources.Domain.Payment))]
        public Client Client { get; set; }

        [Display(Name = nameof(Sum), ResourceType = typeof(Resources.Domain.Payment))]
        public decimal Sum { get; set; }

        [Display(Name = nameof(PaymentTime), ResourceType = typeof(Resources.Domain.Payment))]
        public DateTime PaymentTime { get; set; }
    }
}