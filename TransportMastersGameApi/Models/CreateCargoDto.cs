using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Models
{
    public class CreateCargoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int StartLocation { get; set; }
        public int Destination { get; set; }
        public bool Available { get; set; }
    }
}
