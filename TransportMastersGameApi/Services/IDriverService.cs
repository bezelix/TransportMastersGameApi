using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public interface IDriverService
    {
        object Create(CreateDriverDto dto);
        DriverDto GetById(int driverId);
        object GetAllDrivers();
        void Delete(int driverId);
    }
}
