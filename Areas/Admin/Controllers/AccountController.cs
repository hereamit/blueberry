using BlueberryPro.DAL;
using BlueberryPro.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueberryPro.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUser user;

        public AccountController(IUser user)
        {
            this.user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login( UserModel user)
        {
            var data = this.user.Login(user);
            if(data == null)
            {
                ViewBag.Message = "Email or Password inconrect";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult Register()
        {
           // UserRepository user = new UserRepository();


            return View();
        }

        [HttpPost]

        public IActionResult Register(UserModel user)
        {

            this.user.Insert(user);
            return View();
        }
    }
}
