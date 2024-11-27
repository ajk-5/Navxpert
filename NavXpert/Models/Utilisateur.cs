using System.ComponentModel.DataAnnotations;


namespace NavXpert.Models
{
    public class Utilisateur
    {
        public int ID;

        [Required]
        public string UserName;

        [Required]
        public string FirstName;

        [Required]
        public string LastName;

        [Required]
        [EmailAddress]
        public string Email;

       
         public string PhoneNumber;

        [Required]
        public string Password;

    }
}
