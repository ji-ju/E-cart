using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newproj.Models;

namespace Newproj.Controllers
{
    public class AssistantsController : Controller
    {
        private readonly ApplicationUser _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AssistantsController(ApplicationUser context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Assistants
        public async Task<IActionResult> Index()
        {
            var applicationUser = _context.Assistants.Include(a => a.City).Include(a => a.Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> SelectBooking(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> Mechanic(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> Plumber(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> Painter(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> Carpenter(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> Electrician(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        public async Task<IActionResult> Gardner(int? Profession, int? City)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            var applicationUser = _context.Assistants.Include(b => b.City).Include(b => b.Profession).Where(b => b.CityId == City && b.ProfId == Profession);
            return View(await applicationUser.ToListAsync());
        }
        // GET: Assistants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistants
                .Include(a => a.City)
                .Include(a => a.Profession)
                .FirstOrDefaultAsync(m => m.AssistId == id);
            if (assistant == null)
            {
                return NotFound();
            }

            return View(assistant);
        }

        // GET: Assistants/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName");
            return View();
        }

        // POST: Assistants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssistId,Username,Pwd,Confirmpassword,Email,CityId,ProfId,Address,PhoneNumber,ImageName,ImageFile")] Assistant assistant)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(assistant.ImageFile.FileName);
                string extension = Path.GetExtension(assistant.ImageFile.FileName);
                assistant.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/UpImage/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await assistant.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(assistant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login","Home");
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", assistant.CityId);
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName", assistant.ProfId);
            return View(assistant);
        }
        public async Task<IActionResult> BookedSuccessfull(string name)
        {
            // string search = "Electrician";
            var booking = await _context.Assistants
                .Include(b => b.City)
                .Include(b => b.Profession)
                .FirstOrDefaultAsync(m => m.Username ==name);
           // var users = _context.Assistants.Where(t => t.Username.Contains(name));


            return View(booking);

        }
        // GET: Assistants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistants.FindAsync(id);
            if (assistant == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", assistant.CityId);
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName", assistant.ProfId);
            return View(assistant);
        }

        // POST: Assistants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssistId,Username,Pwd,Confirmpassword,Email,CityId,ProfId,Address,PhoneNumber,ImageName")] Assistant assistant)
        {
            if (id != assistant.AssistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistantExists(assistant.AssistId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", assistant.CityId);
            ViewData["ProfId"] = new SelectList(_context.Professions, "ProfId", "ProfessionName", assistant.ProfId);
            return View(assistant);
        }

        // GET: Assistants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistants
                .Include(a => a.City)
                .Include(a => a.Profession)
                .FirstOrDefaultAsync(m => m.AssistId == id);
            if (assistant == null)
            {
                return NotFound();
            }

            return View(assistant);
        }

        // POST: Assistants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assistant = await _context.Assistants.FindAsync(id);
            _context.Assistants.Remove(assistant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistantExists(int id)
        {
            return _context.Assistants.Any(e => e.AssistId == id);
        }
    }
}
