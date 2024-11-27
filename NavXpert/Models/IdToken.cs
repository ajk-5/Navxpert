using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace NavXpert.Models
{
    public class IdToken
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        public bool IsUsed { get; set; }

    }
}
