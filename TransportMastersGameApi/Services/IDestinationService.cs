using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public interface IDestinationService
    {
        object Create(CreateDestinationDto dto);
        DestinationDto GetById(int destinationId);
        object GetAllDestinations();
        void Delete(int destinationId);
    }
}
