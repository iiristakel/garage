using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class WorkerOnObjectCreateEditViewModel
    {
        public WorkerOnObject WorkerOnObject { get; set; }
        public SelectList WorkObjectSelectList { get; set; }
        public SelectList WorkerSelectList { get; set; }
    }
}