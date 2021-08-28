using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
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
        private readonly IToastNotification _toastNotification;



        public HomeController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            ViewBag.data = HttpContext.Session.GetString("UserId");

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
            if (ModelState.IsValid)
            {
                ViewBag.data = HttpContext.Session.GetString("UserId");
                var model = await _context.TripUsers.AddAsync(new TripUser()
                {
                    TripId = tripId,
                    UserId = new Guid(ViewBag.data)
                });
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage(" Successfully booked ");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid booked");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> GetAllMyTrip()
        {
            ViewBag.data = HttpContext.Session.GetString("UserId");
            var userId = new Guid(ViewBag.data);
            var model = await _context.TripUsers
                .Include(d => d.Trip)
                .Include(d => d.User)
                .Where(d => d.UserId == userId)
                .Select(d => new MyReservationViewModel
                {
                    CityName = d.Trip.CityName,
                    ImageUrl = d.Trip.ImageUrl,
                    Price = d.Trip.Price,
                    Title = d.Trip.Title,
                    UserName = d.User.Name
                }).ToListAsync();
            return View(model);
        }
    }
}

