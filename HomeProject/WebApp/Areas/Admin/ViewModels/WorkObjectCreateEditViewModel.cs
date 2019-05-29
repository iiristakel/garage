using System.Collections.Generic;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class WorkObjectCreateEditViewModel
    {
        public BLL.App.DTO.WorkObject WorkObject { get; set; }
        public SelectList ClientSelectList { get; set; }

        public ICollection<AppUserOnObject> AppUsersOnObject { get; set; }
        public ICollection<ProductService> ProductsServices { get; set; }
        public ICollection<Bill> Bills { get; set; }



    }
}