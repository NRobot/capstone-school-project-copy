using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTVStreamingService.Data;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Controllers
{
    public class ShowServiceController : Controller
    {
        private readonly MyTVContext _context;

        public ShowServiceController(MyTVContext context)
        {
            _context = context;
        }

        // GET: ShowService
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShowService.ToListAsync());
        }

        // GET: ShowService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showService = await _context.ShowService
                .FirstOrDefaultAsync(m => m.ID == id);
            if (showService == null)
            {
                return NotFound();
            }

            return View(showService);
        }

        // GET: ShowService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShowService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ShowFK,ServiceFK")] ShowService showService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showService);
        }

        // GET: ShowService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showService = await _context.ShowService.FindAsync(id);
            if (showService == null)
            {
                return NotFound();
            }
            return View(showService);
        }

        // POST: ShowService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ShowFK,ServiceFK")] ShowService showService)
        {
            if (id != showService.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowServiceExists(showService.ID))
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
            return View(showService);
        }

        // GET: ShowService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showService = await _context.ShowService
                .FirstOrDefaultAsync(m => m.ID == id);
            if (showService == null)
            {
                return NotFound();
            }

            return View(showService);
        }

        // POST: ShowService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showService = await _context.ShowService.FindAsync(id);
            _context.ShowService.Remove(showService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowServiceExists(int id)
        {
            return _context.ShowService.Any(e => e.ID == id);
        }
    }
}
