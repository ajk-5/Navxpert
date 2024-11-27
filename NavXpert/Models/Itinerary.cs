using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NavXpert.Models
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }


        public Address Departure { get; set; }

        public Address Destination { get; set; }

        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public List<TransportLine> TransportLines { get; set;}


    }
}
