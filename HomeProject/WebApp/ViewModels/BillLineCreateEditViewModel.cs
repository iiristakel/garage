using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class BillLineCreateEditViewModel
    {
        public BLL.App.DTO.BillLine BillLine { get; set; }
        public SelectList BillSelectList { get; set; }
        public SelectList ProductForClientSelectList { get; set; }
        
    }
}