using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class Address
    {
        [Required]
        public int RueNumber { get; set; }
        [Required]
        public string RueType { get; set; }
        [Required]
        public string RueName { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
    }
}
