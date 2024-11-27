using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class TransportLine
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Obligatory field")]
        public List<Station> Station { get; set; }
        [Required(ErrorMessage = "Obligatory Transport type ")]
        public TransportType transportType{get; set;}
        [Required(ErrorMessage = "Obligatory Direction ")]
        public string Direction { get; set; }
        [Required(ErrorMessage = "Obligatory LineState")]
        public string LineState { get; set; }

    }
}
