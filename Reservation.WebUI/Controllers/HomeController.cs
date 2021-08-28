using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Repository.TripUser;
using Reservation.Core.Entities;
using Reservation.Infrastructure.Data.ApplicationDbContext;
using Reservation.WebUI.Service;
using Reservation.WebUI.ViewModel;

namespace Reservation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly ITripUser _tripUser;


        public HomeController(ApplicationDbContext context, IUserService userService, ITripUser tripUser)
        {
            _context = context;
            _userService = userService;
            _tripUser = tripUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            if (TempData["UserId"] != null)
            {
                var userId = TempData["UserId"];
            }

            var model = await _context.Trips.Where(d => d.Title.Contains(name)
                                                        || name == null)
                .Select(d => new CardHomeViewModel()
                {

                    Title = d.Title,
                    CityName = d.CityName,
                    Price = d.Price,
                    ImageUrl = d.ImageUrl,
                    Id = d.Id
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Reservation()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Reservation(Guid tripId)
        {
            var userId = TempData["UserId"];
            var model = await _context.TripUsers.AddAsync(new TripUser()
            {
                TripId = tripId,
                UserId = new Guid(userId.ToString() ?? string.Empty)
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
 
