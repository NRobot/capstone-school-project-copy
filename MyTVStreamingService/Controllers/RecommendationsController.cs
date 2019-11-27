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
                if (!showAlreadyCarried)
                {
                    // No service already in list carries show.  Add cheapest service to list.
                    workingSet.Add(servicesList.First().ID, servicesList.First());
                }
            }

            ViewData["Services"] = workingSet.Values.ToList();

            string Placeholder_Service;

            // loop through services
            // loop through shows 
            // store matching shows + service into sorted list
            // store sorted list in view data for html
            foreach (var serv in ViewData["Services"] as List<Service>)
            {
                SortedList<int, Show> showSet = new SortedList<int, Show>();
                Placeholder_Service = serv.name;

                foreach (int showId in showIds)
                {
                    var showList =
                    (from showService in _context.Set<ShowService>()
                     join show in _context.Set<Show>() on showService.ShowFK equals show.Id
                     join service in _context.Set<Service>() on showService.ServiceFK equals service.ID
                     where show.Id == showId
                     where Placeholder_Service == service.name
                     select show).ToList();

                    if (showList.Count != 0)
                    {
                        showSet.Add(showId, showList.First());
                    }
                }
                ViewData[Placeholder_Service] = showSet.Values.ToList();
            }

            return View("Recommendation");
        }
    }
}
