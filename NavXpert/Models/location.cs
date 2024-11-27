using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class location
    {
        [Required]
        public double Latitude {  get; set; }
        [Required]
        public double Longitude{get; set; }
        [Required]
        public User UserLocation { get; set; }

    }
}
