using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyTVStreamingService.Models
{
    public class MyTVUser : IdentityUser
    {

        [Display(Name = "First Name"), StringLength(60, MinimumLength = 3)]//, Required]
        public String FirstName { get; set; }

        [Display(Name = "Last Name"), StringLength(60, MinimumLength = 3)]//, Required]
        public String LastName { get; set; }


        [Display(Name = "Account Creation Date"), DataType(DataType.Date)]
        public DateTime AccCreationDate { get; set; }

    }
}