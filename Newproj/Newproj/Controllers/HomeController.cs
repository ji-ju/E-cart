using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newproj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationUser _context;

        public HomeController(ApplicationUser context)
        {
            _context = context;
        }

      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Assistant user)
        {
            var account = _context.Assistants.Where(u => u.Username == user.Username && u.Pwd == user.Pwd).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("AssistId", account.AssistId.ToString());
                HttpContext.Session.SetString("Username", account.Username.ToString());
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
            }
            return View();
        }
        public Booking Bookings { get; set; }
        public async Task<IActionResult> Welcome()
        {
            if (HttpContext.Session.GetString("AssistId") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                String Asst = HttpContext.Session.GetString("Username"); ;
                ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
                ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
                var applicationUser = _context.Bookings.Include(b => b.City).Include(b => b.Profession).Where(a => a.AssistantName.Contains(Asst));
                return View(await applicationUser.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
 

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Email(string Status, string email,int id)
        {
            var Booking = await _context.Bookings.FindAsync(id);
            Booking.Status =Status;
            await _context.SaveChangesAsync();
            return await Task.Run(() =>
            {
                ////var email = form["email"];
                var message = Status;
                var isHtml = true;
                var result = Newproj.Models.Email.Send("Email from Website", message, email, isHtml, null);
                if (string.IsNullOrEmpty(result))
                    result = "Your message was sucessfully sent.";

                return RedirectToAction("Welcome");
            });

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
