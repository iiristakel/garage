using System.Collections.Generic;
using BLL.App.DTO;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class AppUserCreateEditViewModel
    {
        
            public BLL.App.DTO.Identity.AppUser AppUser { get; set; }
            public SelectList AppUserPositionSelectList { get; set; }
          
    }
}