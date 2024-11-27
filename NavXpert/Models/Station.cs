using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TransportLine> TransportLines { get; set; }
    }
}
