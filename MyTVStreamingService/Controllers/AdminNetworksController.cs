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
    public class AdminNetworksController : Controller
    {
        private readonly MyTVStreamingServiceContext _context;

        public AdminNetworksController(MyTVStreamingServiceContext context)
        {
            _context = context;
        }

        // GET: AdminNetworks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminNetwork.ToListAsync());
        }

        // GET: AdminNetworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminNetwork = await _context.AdminNetwork
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adminNetwork == null)
            {
                return NotFound();
            }

            return View(adminNetwork);
        }

        // GET: AdminNetworks/Create
        public IActionResult Create()
        {
            PopulateServiceDropDownList();
            return View();
        }

        // POST: AdminNetworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AdminServiceID,Network")] AdminNetwork adminNetwork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminNetwork);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(AdminService));
                return RedirectToAction("Index", "AdminServices");
            }
            PopulateServiceDropDownList();
            return View(adminNetwork);

        }

        // GET: AdminNetworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminNetwork = await _context.AdminNetwork.FindAsync(id);
            if (adminNetwork == null)
            {
                return NotFound();
            }
            return View(adminNetwork);
        }

        // POST: AdminNetworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AdminServiceID,Network")] AdminNetwork adminNetwork)
        {
            if (id != adminNetwork.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminNetwork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminNetworkExists(adminNetwork.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "AdminServices");
            }
            return View(adminNetwork);
        }

        // GET: AdminNetworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminNetwork = await _context.AdminNetwork
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adminNetwork == null)
            {
                return NotFound();
            }

            return View(adminNetwork);
        }

        // POST: AdminNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminNetwork = await _context.AdminNetwork.FindAsync(id);
            _context.AdminNetwork.Remove(adminNetwork);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "AdminServices");
        }

        private bool AdminNetworkExists(int id)
        {
            return _context.AdminNetwork.Any(e => e.ID == id);
        }

        private void PopulateServiceDropDownList()
        {
            var servicesQuery = from d in _context.AdminService
                               orderby d.Service
                               select d;
            ViewBag.AdminServiceID = new SelectList(servicesQuery, "Id", "Service");
        }
    }
}
