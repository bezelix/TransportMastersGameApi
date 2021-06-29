using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public interface ICargoService
    {
        object Create(CreateCargoDto dto);
        CargoDto GetById(int cargoId);
        object GetAll();
        void Delete(int cargoId);
        void ChangeAvailable(int cargoId);
        void CreateRandomCargo(CreateDestinationDto dto);
    }
}
