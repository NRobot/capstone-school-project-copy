using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTVStreamingService.Data;
using MyTVStreamingService.Models;

namespace MyTVStreamingService.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RecommendedsController : Controller
    {
        private readonly MyTVContext _context;

        public RecommendedsController(MyTVContext context)
        {
            _context = context;
        }

        // GET: Recommendeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recommended.ToListAsync());
        }

        // GET: Recommendeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommended = await _context.Recommended
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recommended == null)
            {
                return NotFound();
            }

            return View(recommended);
        }

        // GET: Recommendeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recommendeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,userID,show,count")] Recommended recommended)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recommended);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recommended);
        }

        // GET: Recommendeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommended = await _context.Recommended.FindAsync(id);
            if (recommended == null)
            {
                return NotFound();
            }
            return View(recommended);
        }

        // POST: Recommendeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,userID,show,count")] Recommended recommended)
        {
            if (id != recommended.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recommended);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecommendedExists(recommended.ID))
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
            return View(recommended);
        }

        // GET: Recommendeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommended = await _context.Recommended
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recommended == null)
            {
                return NotFound();
            }

            return View(recommended);
        }

        // POST: Recommendeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recommended = await _context.Recommended.FindAsync(id);
            _context.Recommended.Remove(recommended);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecommendedExists(int id)
        {
            return _context.Recommended.Any(e => e.ID == id);
        }
    }
}
