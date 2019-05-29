using System.Collections.Generic;
using BLL.App.DTO;
using BLL.App.DTO.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class BillCreateEditViewModel
    {
        public BLL.App.DTO.Bill Bill { get; set; }
        public SelectList ClientSelectList { get; set; }

        public SelectList WorkObjectSelectList { get; set; }

        public ICollection<BillLine> BillLines { get; set; }

    }
}