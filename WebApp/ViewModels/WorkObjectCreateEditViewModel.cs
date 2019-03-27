using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class WorkObjectCreateEditViewModel
    {
        public WorkObject WorkObject { get; set; }
        public SelectList ClientSelectList { get; set; }

    }
}