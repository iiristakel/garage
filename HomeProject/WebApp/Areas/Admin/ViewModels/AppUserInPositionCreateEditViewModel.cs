using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class AppUserInPositionCreateEditViewModel
    {
        public BLL.App.DTO.AppUserInPosition AppUserInPosition { get; set; }

        public BLL.App.DTO.Identity.AppUser AppUser { get; set; }

        public SelectList AppUserSelectList { get; set; }
        public SelectList AppUserPositionSelectList { get; set; }
    }
}