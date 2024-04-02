using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingAPI.Models;
namespace StreamingWeb.ViewModels
{
    public class UserViewModel
    {
        public Client? User { get; set; }
        public Admin? Admin { get; set; }
        public bool Authentifie { get; set; }


    }
}
