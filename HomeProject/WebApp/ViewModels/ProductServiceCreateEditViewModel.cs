using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ProductServiceCreateEditViewModel
    {
        public ProductService ProductService { get; set; }
        public SelectList ProductForClientSelectList { get; set; }
        public SelectList WorkObjectSelectList { get; set; }

    }
}