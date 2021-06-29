using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public interface IDeliveryService
    {
        object Create(int userId, CreateDeliveryDto dto);
        DeliveryDto GetById(int userId, int deliveryId);
        object GetAll(int userId);
        void DeleteAll(int userId);
        void Delete(int deliveryId);
    }
}
