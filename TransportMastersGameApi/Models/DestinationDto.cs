using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi.Models
{
    public class DestinationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Cargo> Cargos { get; set; }
    }
}
