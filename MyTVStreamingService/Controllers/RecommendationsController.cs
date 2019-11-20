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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
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
                    return View("Recommendation");
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

            ViewData["Services"] = workingSet.Values.ToList();
            ViewData["Shows"] = (from show in _context.Set<Show>()
                                where showIds.Contains(show.Id)
                                select show).ToList();
            return View("Recommendation");
        }

        private bool RecommendationExists(int id)
        {
            return _context.Recommendation.Any(e => e.Id == id);
        }
    }
}
