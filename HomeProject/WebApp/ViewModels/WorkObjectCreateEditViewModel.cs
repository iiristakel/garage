using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class WorkObjectCreateEditViewModel
    {
        public BLL.App.DTO.WorkObject WorkObject { get; set; }
        public SelectList ClientSelectList { get; set; }

    }
}