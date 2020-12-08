using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data3;
using Data3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RailwaysBG.Models;
using RailwaysBG.Models.Home;
using RailwaysBG.Utils;

namespace RailwaysBG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                using RailwayDbContext context = new RailwayDbContext();
                User loggedUser = context.Users.FirstOrDefault(u =>
                    u.Username == model.Username &&
                    u.Password == model.Password);
                if (loggedUser == null)
                    ModelState.AddModelError("AuthError", "Invalid username and password!");
                else
                {
                    LoggedUser lu = new LoggedUser
                    {
                        Id = loggedUser.Id,
                        Username = loggedUser.Username,
                        FirstName = loggedUser.FirstName,
                        IsAdmin = loggedUser.IsAdmin,
                        LastName = loggedUser.LastName
                    };
                    HttpContext.Session.SetObjectAsJson("loggedUser", lu);
                }
            }
            if (!ModelState.IsValid)
                return View(model);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
