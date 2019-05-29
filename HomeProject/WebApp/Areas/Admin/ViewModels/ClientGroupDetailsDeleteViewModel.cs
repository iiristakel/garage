using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ClientGroupDetailsDeleteViewModel
    {
        public ClientGroup ClientGroup { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}