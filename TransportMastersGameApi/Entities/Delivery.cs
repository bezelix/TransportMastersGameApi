using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CargoId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int StartLocationId { get; set; }
        public int DestinationId { get; set; }
        public float RouteLength { get; set; }
        public DateTime StartTime { get; set; }


    }
}
