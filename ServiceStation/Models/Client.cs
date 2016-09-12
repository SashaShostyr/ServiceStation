using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Models
{
    public class Client
    {

        public int Id { get; set; }
        // FirstName
        [Required]
        [Display(Name = " FirstName ")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string FirstName { get; set; }
        // LastName
        [Required]
        [Display(Name = "LastName")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string LastName { get; set; }
        // Login
        [Required]
        [Display(Name = "Login")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Login { get; set; }
        // DateOfBirth
        [Required]
        [Display(Name = "Password")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Password { get; set; }
        // DateOfBirth
        [Display(Name = "DateOfBirth")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string DateOfBirth { get; set; }
        // Adress
        [Required]
        [Display(Name = "Adress")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Adress { get; set; }
        // Phone
        [Required]
        [Display(Name = "Phone")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Phone { get; set; }
        // Email
        [Required]
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Email { get; set; }   
    }
}