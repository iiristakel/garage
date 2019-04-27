using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class AppUserOnObjectCreateEditViewModel
    {
        public AppUserOnObject AppUserOnObject { get; set; }
        public SelectList WorkObjectSelectList { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}