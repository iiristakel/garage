using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ClientCreateEditViewModel
    {
        public BLL.App.DTO.Client Client { get; set; }
        public SelectList ClientGroupSelectList { get; set; }
    }
}