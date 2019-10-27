using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyTVStreamingService.Models
{
    public class MyTVUser : IdentityUser<int>
    {
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