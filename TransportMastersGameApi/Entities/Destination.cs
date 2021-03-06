using System.Collections.Generic;

namespace TransportMastersGameApi.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public int Continent { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual  List<Cargo> Cargos { get; set; }
    }
}