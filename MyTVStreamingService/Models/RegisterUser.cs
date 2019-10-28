using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MyTVStreamingService.Models
{
    public class RegisterUser
    {
        //[Required]
        //[FirstName]
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }

        //[Required]
        //[LastName(DataType.Text)]
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
