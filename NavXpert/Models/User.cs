﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace NavXpert.Models
{
    public class User: IdentityUser
    {
        [Key]
        [Required]
        public int Id;

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? PhoneNumber {  get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }


        [Required]
        public DateOnly DOB { get; set;}

    }
}
