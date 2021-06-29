using System;

namespace TransportMastersGameApi.Models
{
    public class CreateDeliveryDto
    {
        public int UserId { get; set; }
        public int CargoId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public float RouteLength { get; set; }
        public DateTime StartTime { get; set; }
    }
}