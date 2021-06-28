﻿namespace TransportMastersGameApi.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }

    }
}