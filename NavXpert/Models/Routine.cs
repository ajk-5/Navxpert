using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public Itinerary? Itinerary { get; set; }
        [Required]
        public User Users { get; set; }
        [Required]
        public Address Adress { get; set; }

    }
}
