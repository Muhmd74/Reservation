using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entities;
using Reservation.Infrastructure.Data.ApplicationDbContext;
using Reservation.WebUI.ViewModel;

namespace Reservation.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new User
                {
                     Email = model.Email,
                    Name = model.Name,
                    Address = model.Address,
                     Phone = model.Phone,
                     Password = model.Password,
                    
                };

                var result = await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
        
                    return RedirectToAction("index", "home");
               
            }

            return View(model);
        }
        [HttpGet]
         public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _context.Users.FirstOrDefaultAsync(d =>
                        d.Email == model.Email && d.Password == model.Password);

                if (result!=null)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        TempData["UserId"] = result.Id;
                        return RedirectToAction("index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}
