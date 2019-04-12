using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class BillCreateEditViewModel
    {
        public Bill Bill { get; set; }
        public SelectList ClientSelectList { get; set; }
    }
}