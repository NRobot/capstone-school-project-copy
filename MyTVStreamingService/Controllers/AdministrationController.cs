﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<MyTVRole> _roleManager;

        public AdministrationController(RoleManager<MyTVRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                MyTVRole identityRole = new MyTVRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}