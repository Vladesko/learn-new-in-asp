using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLiteWork.Entityes;
using SQLiteWork.Logic;
using SQLiteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWork.Controllers
{
    public class HomeController : Controller
    {
        private DemoContext context;
        private Commands commands;
        public HomeController(DemoContext context)
        {
            this.context = context;
            commands = new Commands(this.context);
        }
        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuth = User.Identity.IsAuthenticated;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                commands.Add(user);
            }

            return Redirect("/Home/Index");
        }
        public IActionResult GetTable()
        {
            return View(commands.GetTable());
        }
    }
}
