using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoesECommerce.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

        public string MobilePhone { get; set; }

        public string CreditCard { get; set; }

        public string Address { get; set; }

        public string FullName { get; set; }

    }

    /// <summary>
    /// View model for the registration page
    /// </summary>
    public class RegistrationViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {   
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}