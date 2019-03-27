using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class WorkerInPositionCreateEditViewModel
    {
        public WorkerInPosition WorkerInPosition { get; set; }
        public SelectList WorkerSelectList { get; set; }
        public SelectList WorkerPositionSelectList { get; set; }
    }
}