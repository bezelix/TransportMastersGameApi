using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public interface IVehicleService
    {
        object Create(CreateVehicleDto dto);
        void Delete(int vehicleId);
        VehicleDto GetById(int vehicleId);
        object GetAllVehicle();
        List<VehicleDto> GetAllOnMarketplace();
    }
}
