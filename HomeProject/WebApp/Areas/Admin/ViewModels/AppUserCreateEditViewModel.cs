using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class AppUserCreateEditViewModel
    {
        
            public BLL.App.DTO.Identity.AppUser AppUser { get; set; }
            public MultiSelectList AppUserPositionSelectList { get; set; }
        
    }
}