using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SQLiteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SQLiteWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Person> userManager;
        private readonly SignInManager<Person> signInManager;
        public AccountController(UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new PersonLogin() {ReturnUrl = returnUrl});
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(PersonLogin model)
        {
            if (ModelState.IsValid)
            {
                var loginRes = await signInManager.PasswordSignInAsync(model.LogIn, model.Password,
                    false, lockoutOnFailure: false);
                if (loginRes.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index","Account");
                }
            }
            ModelState.AddModelError("","User not found");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(PersonRegistration model)
        {
            if (ModelState.IsValid) 
            {
                var person = new Person { UserName = model.LogIn };
                var createRes = await userManager.CreateAsync(person, model.Password);

                if (createRes.Succeeded)
                {
                    await signInManager.SignInAsync(person, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in createRes.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
           await signInManager.SignOutAsync();
           return Redirect("/Home/Index");
        }
    }
}
