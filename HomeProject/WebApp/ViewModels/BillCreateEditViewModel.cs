using System.Collections.Generic;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class BillCreateEditViewModel
    {
        public BLL.App.DTO.Bill Bill { get; set; }
        
        
        public SelectList ClientSelectList { get; set; }
    }
}