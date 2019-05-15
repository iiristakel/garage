using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ProductsForClientsCreateEditViewModel
    {
        public BLL.App.DTO.ProductForClient ProductForClient { get; set; }
        public SelectList ClientSelectList { get; set; }
        public SelectList ProductSelectList { get; set; }
        public SelectList WorkObjectSelectList { get; set; }
    }
}