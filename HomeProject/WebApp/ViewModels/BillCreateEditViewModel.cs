using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class BillCreateEditViewModel
    {
        public BLL.App.DTO.Bill Bill { get; set; }
        public SelectList ClientSelectList { get; set; }
    }
}