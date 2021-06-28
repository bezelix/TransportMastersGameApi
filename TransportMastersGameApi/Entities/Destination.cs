using System.Collections.Generic;

namespace TransportMastersGameApi.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual  List<Cargo> Cargos { get; set; }
    }
}