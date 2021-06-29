using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Models
{
    public class DeliveryDto
    {
        public int UserId { get; set; }
        public int CargoId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public float RouteLength { get; set; }
        public DateTime StartTime { get; set; }

    }
}
