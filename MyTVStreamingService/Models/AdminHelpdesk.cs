using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyTVStreamingService.Models
{
    public class AdminHelpdesk
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Title { get; set; }

        [Display(Name = "Username"), StringLength(60, MinimumLength = 3), Required]
        public string Username { get; set; }

        [Display(Name = "Email"), DataType(DataType.EmailAddress), Required]
        public String EmailAddress { get; set; }

        [MinLength(3), DataType(DataType.MultilineText), Required]
        public string Message { get; set; }

        [Display(Name = "Arrival Time"), DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; } = DateTime.Now;
    }
}
