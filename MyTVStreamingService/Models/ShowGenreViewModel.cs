using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyTVStreamingService.Models
{
    public class ShowGenreViewModel
    {
        public List<Show> Shows { get; set; }
        public SelectList Genres { get; set; }
        public string ShowGenre { get; set; }
        public string SearchString { get; set; }
    }
}