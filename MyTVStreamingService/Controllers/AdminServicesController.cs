using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Controllers
{
    public class AdminServicesController : Controller
    {
        private readonly MyTVStreamingServiceContext _context;

        public AdminServicesController(MyTVStreamingServiceContext context)
        {
            _context = context;
        }

        // GET: AdminServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminService.ToListAsync());
        }

        // GET: AdminServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminService = await _context.AdminService
                .Include(m => m.AdminNetworks)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminService == null)
            {
                return NotFound();
            }

            return View(adminService);
        }

        // GET: AdminServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Service,Price")] AdminService adminService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminService);
        }

        // GET: AdminServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminService = await _context.AdminService.FindAsync(id);
            if (adminService == null)
            {
                return NotFound();
            }
            return View(adminService);
        }

        // POST: AdminServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Service,Price")] AdminService adminService)
        {
            if (id != adminService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminServiceExists(adminService.Id))
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
            return View(adminService);
        }

        // GET: AdminServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminService = await _context.AdminService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminService == null)
            {
                return NotFound();
            }

            return View(adminService);
        }

        // POST: AdminServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminService = await _context.AdminService.FindAsync(id);
            _context.AdminService.Remove(adminService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminServiceExists(int id)
        {
            return _context.AdminService.Any(e => e.Id == id);
        }
    }
}
