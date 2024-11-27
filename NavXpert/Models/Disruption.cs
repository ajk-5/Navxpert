using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class Disruption
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public TransportLine DisruptionLine { get; set; }

    }
}   

