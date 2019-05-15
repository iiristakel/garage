using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class WorkObjectCreateEditViewModel
    {
        public BLL.App.DTO.WorkObject WorkObject { get; set; }
        public SelectList ClientSelectList { get; set; }

    }
}