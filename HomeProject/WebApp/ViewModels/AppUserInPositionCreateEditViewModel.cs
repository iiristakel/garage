using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class AppUserInPositionCreateEditViewModel
    {
        public BLL.App.DTO.AppUserInPosition AppUserInPosition { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList AppUserPositionSelectList { get; set; }
    }
}