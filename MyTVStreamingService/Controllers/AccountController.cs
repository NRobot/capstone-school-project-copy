using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MyTVUser> UserMgr { get; }
        private SignInManager<MyTVUser> SignInMgr { get; }

        public AccountController(UserManager<MyTVUser> userManager,
            SignInManager<MyTVUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("TestUser", "Test123!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                MyTVUser user = await UserMgr.FindByNameAsync("TestUser");
                if (user == null)
                {
                    user = new MyTVUser
                    {
                        UserName = "TestUser",
                        EmailAddress = "TestUser@test.com",
                        FirstName = "John",
                        LastName = "Wick",
                        AccCreationDate = DateTime.Now
                    };

                    IdentityResult result = await UserMgr.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
    }
}