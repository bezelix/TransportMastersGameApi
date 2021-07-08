using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Services
{
    public interface IModerationCommands
    {
        void CargoCreate();
        void AddVehicle();
        void AddDriver();
    }
}
