using AutoMapper;
using FirstStepsDotNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Controllers;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ICargoService _ICargoService;
        private readonly TransportMastersGameDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DeliveryService> _logger;

        public DeliveryService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<DeliveryService> logger, ICargoService cargoController)
        {
            _ICargoService = cargoController;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        private User GetUserById(int userId)
        {
            var user = _dbContext
                            .Users
                            .FirstOrDefault(r => r.Id == userId);

            if (user is null)
                throw new NotFoundException("Delivery not found");
            return user;
        }

        public object Create(int userId, CreateDeliveryDto dto)
        {
            var delivery = _mapper.Map<Delivery>(dto);
            delivery.UserId = userId;
            delivery.StartTime = DateTime.Now;
            _dbContext.Deliveries.Add(delivery);
            _dbContext.SaveChanges();
            _ICargoService.ChangeAvailable(dto.CargoId);
            return delivery.Id;
        }

        public object GetAllUserDelivery(int userId)
        {
            var users = GetUserById(userId);
            var deliveriesDtos = _mapper.Map<List<DeliveryDto>>(users.Deliveries);   // mapuje liste dań dla restauracji 
            return deliveriesDtos;
        }

        public DeliveryDto GetById(int userId, int deliveryId)
        {
            var users = GetUserById(userId);
            var delivery = _dbContext
                            .Deliveries
                            .FirstOrDefault(d => d.Id == deliveryId);    //(r => r.Id == id) predykata

            if (delivery is null || delivery.UserId != userId)
            {
                throw new NotFoundException("Delivery not found");
            }
            var deliveryDto = _mapper.Map<DeliveryDto>(delivery);
            return deliveryDto;
        }
        public void Delete(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
