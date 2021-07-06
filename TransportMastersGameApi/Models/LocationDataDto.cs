using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Models
{
    public class LocationDataDto
    {
        public int State { get; set; }
        public int Country { get; set; }
        public int Continent { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Name { get; set; }
    }
}
