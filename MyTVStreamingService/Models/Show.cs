using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTVStreamingService.Models
{
    public class Show
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public String Title { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public String Genre { get; set; }

        [Display(Name = "Number of Seasons")]
        public int NumberOfSeasons { get; set; }

        [Range(1, 10), Required]
        public double Rating { get; set; }
    }
}
