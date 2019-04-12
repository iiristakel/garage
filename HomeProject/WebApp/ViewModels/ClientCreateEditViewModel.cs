using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ClientCreateEditViewModel
    {
        public Client Client { get; set; }
        public SelectList ClientGroupSelectList { get; set; }
    }
}