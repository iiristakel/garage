using System.Collections.Generic;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ClientCreateEditViewModel
    {
        public BLL.App.DTO.Client Client { get; set; }
        public SelectList ClientGroupSelectList { get; set; }

//        public ICollection<Bill> Bills { get; set; }
        
//        public ICollection<ProductForClient> ProductsForClient { get; set; }

    }
}