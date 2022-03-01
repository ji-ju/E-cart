using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newproj.Models;

namespace Newproj.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationUser _context;

        public BookingsController(ApplicationUser context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var applicationUser = _context.Bookings.Include(b => b.City).Include(b => b.Profession);
            return View(await applicationUser.ToListAsync());
        }
        //public IActionResult SelectBooking(int? Profession, int? City)
        //{
        //    ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
        //    ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
        //    var applicationUser = _context.Bookings.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
        //    return View(applicationUser.ToList());
        //}
        public async Task<IActionResult> BookedSuccessfull(string name)
        {
            // string search = "Electrician";
            var booking = await _context.Assistants
                .Include(b => b.City)
                .Include(b => b.Profession)
                .FirstOrDefaultAsync(m => m.Username == name);
            // var users = _context.Assistants.Where(t => t.Username.Contains(name));


            return View(booking);

        }
        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.City)
                .Include(b => b.Profession)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create(string name)
        {
            if (name!=null)
            {
                ViewBag.AssistantName = name;
                ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
                ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
                return View();
            }
            return NotFound();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,Username,Email,CityId,ProfId,AssistantName,Address,Date,PhoneNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("BookedSuccessfull", new {name=booking.AssistantName});
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", booking.CityId);
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName", booking.ProfId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", booking.CityId);
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName", booking.ProfId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,Username,Email,CityId,ProfId,AssistantName,Address,Date,PhoneNumber")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", booking.CityId);
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName", booking.ProfId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.City)
                .Include(b => b.Profession)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
