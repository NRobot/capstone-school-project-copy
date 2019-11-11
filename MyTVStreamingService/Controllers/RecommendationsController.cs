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
    public class RecommendationsController : Controller
    {
        private readonly MyTVContext _context;

        public RecommendationsController(MyTVContext context)
        {
            _context = context;
        }

        // GET: Recommendations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recommendation.ToListAsync());
        }

        // GET: Recommendations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendation = await _context.Recommendation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recommendation == null)
            {
                return NotFound();
            }

            return View(recommendation);
        }

        // GET: Recommendations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recommendations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,QueryString")] Recommendation recommendation)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(recommendation);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(recommendation);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int[] rec)
        {
            int[] showIds = rec;
            SortedList<int, Service> workingSet = new SortedList<int, Service>();
            foreach(int showId in showIds)
            {
                var servicesList = 
                (from showService in _context.Set<ShowService>()
                join show in _context.Set<Show>() on showService.ShowFK equals show.Id
                join service in _context.Set<Service>() on showService.ServiceFK equals service.ID
                where show.Id == showId
                orderby service.cost
                select service).ToList();
                
                Console.WriteLine(servicesList.GetType());
                // No service carries the show.
                if(servicesList.Count == 0)
                {
                    Console.WriteLine("Impossible Combination");
                    // return;
                }
                // Check for service already in working set which carries show
                bool showAlreadyCarried = false;
                foreach(Service service in servicesList)
                {
                    if(workingSet.ContainsKey(service.ID))
                    {
                        showAlreadyCarried = true;
                        break;
                    }
                }
                if(showAlreadyCarried)
                {
                    break;
                }
                // No service already in list carries show.  Add cheapest service to list.
                workingSet.Add(servicesList.First().ID, servicesList.First());
            }
            ViewData["Services"] = workingSet.ToList();
            ViewData["Shows"] = (from show in _context.Set<Show>()
                                where showIds.Contains(show.Id)
                                select show).ToList();
            return View("Views/Recommendations/Details.cshtml");
        }

        // GET: Recommendations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendation = await _context.Recommendation.FindAsync(id);
            if (recommendation == null)
            {
                return NotFound();
            }
            return View(recommendation);
        }

        // POST: Recommendations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,QueryString")] Recommendation recommendation)
        {
            if (id != recommendation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recommendation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecommendationExists(recommendation.Id))
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
            return View(recommendation);
        }

        // GET: Recommendations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendation = await _context.Recommendation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recommendation == null)
            {
                return NotFound();
            }

            return View(recommendation);
        }

        // POST: Recommendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recommendation = await _context.Recommendation.FindAsync(id);
            _context.Recommendation.Remove(recommendation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecommendationExists(int id)
        {
            return _context.Recommendation.Any(e => e.Id == id);
        }
    }
}
