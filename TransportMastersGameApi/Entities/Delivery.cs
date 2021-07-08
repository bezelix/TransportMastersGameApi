using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public int? CreatedByUser { get; set; }
        public virtual User CreatedBy { get; set; }
        public int? User { get; set; }
        public int Cargo { get; set; }
        public int Driver { get; set; }
        public int Vehicle { get; set; }
        public int StartLocation { get; set; }
        public int Destination { get; set; }
        public float RouteLength { get; set; }
        public DateTime StartTime { get; set; }


    }
}
