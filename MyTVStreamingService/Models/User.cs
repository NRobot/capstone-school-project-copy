using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTVStreamingService.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Username"), StringLength(60, MinimumLength = 3), Required]
        public String userName { get; set; }

        [Display(Name = "Password"), StringLength(60, MinimumLength = 9), Required]
        public String userPassword { get; set; }
		
		[Display(Name = "First Name"), StringLength(60, MinimumLength = 3), Required]
        public String firstName { get; set; }
		
		[Display(Name = "Last Name"), StringLength(60, MinimumLength = 3), Required]
        public String lastName { get; set; }

		[Display(Name = "Email"), StringLength(60, MinimumLength = 3), Required]
        public String emailAddress { get; set; }

        [Display(Name = "Account Creation Date"), DataType(DataType.Date)]
        public DateTime accCreationDate { get; set; }

        
    }
}
