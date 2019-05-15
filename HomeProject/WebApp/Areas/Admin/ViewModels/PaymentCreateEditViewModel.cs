using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class PaymentCreateEditViewModel
    {
        public BLL.App.DTO.Payment Payment { get; set; }
        public SelectList BillSelectList { get; set; }
        public SelectList ClientSelectList { get; set; }
        public SelectList PaymentMethodSelectList { get; set; }
    }
}