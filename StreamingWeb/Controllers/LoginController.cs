using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingAPI.Models;
using StreamingWeb.ViewModels;
using StreamingWeb.ControllerAPI;
using Microsoft.AspNetCore.Mvc;

namespace StreamingWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel { Authentifie = false };
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    viewModel.User = API.Instance.GetUser(HttpContext.User.Identity.Name).Result;
            //}
            //else
            //{
            //    HttpContext.User.Identity.;
            //}
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel viewModel)
        {
            
            Client user = API.Instance.GetClient(viewModel.User.Id).Result;
           // Admin admin = API.Instance.GetAdmin(viewModel.Admin.Id).Result;
            if (user != null)
            {
                return Redirect("Animes/Index");
            }
          /*  if(admin != null)
            {
                return Redirect("Admins/Index");
            }*/
            ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
            return View(viewModel);
        }

       /* [HttpPost]
        public ActionResult IndexAdmin(UserViewModel viewModel)
        {

           
            Admin admin = API.Instance.GetAdmin(viewModel.Admin.Id).Result;
           
             if(admin != null)
              {
                  return Redirect("Admins/Index");
              }
            ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
            return View(viewModel);
        }*/

        public ActionResult Deconnexion()
        {
            return Redirect("/");
        }
    }
}