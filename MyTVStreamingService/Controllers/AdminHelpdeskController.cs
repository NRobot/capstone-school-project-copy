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
    public class AdminHelpdeskController : Controller
    {
        private readonly MyTVContext _context;

        public AdminHelpdeskController(MyTVContext context)
        {
            _context = context;
        }

        // GET: AdminHelpdesks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminHelpdesk.ToListAsync());
        }

        // GET: AdminHelpdesks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminHelpdesk = await _context.AdminHelpdesk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminHelpdesk == null)
            {
                return NotFound();
            }

            return View(adminHelpdesk);
        }

        // GET: AdminHelpdesks/Create
        public IActionResult Create()
        {
            var newMessage = new AdminHelpdesk();
            return View(newMessage);
        }

        // POST: AdminHelpdesks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Username,EmailAddress,Message,ArrivalTime")] AdminHelpdesk adminHelpdesk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminHelpdesk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminHelpdesk);
        }

        // GET: AdminHelpdesks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminHelpdesk = await _context.AdminHelpdesk.FindAsync(id);
            if (adminHelpdesk == null)
            {
                return NotFound();
            }
            return View(adminHelpdesk);
        }

        // POST: AdminHelpdesks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Username,EmailAddress,Message,ArrivalTime")] AdminHelpdesk adminHelpdesk)
        {
            if (id != adminHelpdesk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminHelpdesk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminHelpdeskExists(adminHelpdesk.Id))
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
            return View(adminHelpdesk);
        }

        // GET: AdminHelpdesks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminHelpdesk = await _context.AdminHelpdesk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminHelpdesk == null)
            {
                return NotFound();
            }

            return View(adminHelpdesk);
        }

        // POST: AdminHelpdesks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminHelpdesk = await _context.AdminHelpdesk.FindAsync(id);
            _context.AdminHelpdesk.Remove(adminHelpdesk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminHelpdeskExists(int id)
        {
            return _context.AdminHelpdesk.Any(e => e.Id == id);
        }
    }
}
