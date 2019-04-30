using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string PaymentMethodValue { get; set; }
    }
}