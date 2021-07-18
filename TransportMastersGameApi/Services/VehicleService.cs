using AutoMapper;
using FirstStepsDotNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public class VehicleService : IVehicleService
    {
        private ICargoService _ICargoService;
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<VehicleService> _logger;

        public VehicleService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<VehicleService> logger, ICargoService cargoController)
        {
            _ICargoService = cargoController;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public object Create(CreateVehicleDto dto)
        {
            var vehicle = _mapper.Map<Vehicle>(dto);
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
            return vehicle.Id;
        }

        public void Delete(int vehicleId)
        {
            var vehicle = _dbContext
                            .Vehicles
                            .FirstOrDefault(r => r.Id == vehicleId);
            if (vehicle is null)
                throw new NotFoundException("Vehicle not found");

            _dbContext.Vehicles.Remove(vehicle);
            _dbContext.SaveChanges();
        }

        public List<VehicleDto> GetAllOnMarketplace()
        {
            var vehicle = _dbContext
                            .Vehicles
                            .Where(item => item.OnMarket==true && item.OfferStartTime.AddHours(24) > DateTime.Now)
                            .ToList();
            var vehicleDtos = _mapper.Map<List<VehicleDto>>(vehicle);
            
            foreach (var item in vehicleDtos)
            {
                item.ModelName = _dbContext
                             .ModelNames
                             .FirstOrDefault(r => r.Id == item.ModelNameNumber).Name;
                item.CarManufacturer = _dbContext
                             .CarManufacturers
                             .FirstOrDefault(r => r.Id == item.CarManufacturerNumber).Name;
                
                item.OfferEndTime = item.OfferStartTime.AddHours(24);
            }
            return vehicleDtos;
        }

        public object GetAllVehicle()
        {
            var vehicle = _dbContext
                            .Vehicles;

            var vehicleDtos = _mapper.Map<List<VehicleDto>>(vehicle);
            return vehicleDtos;
        }

        public VehicleDto GetById(int vehicleId)
        {
            var vehicle = _dbContext
                                        .Vehicles
                                        .FirstOrDefault(d => d.Id == vehicleId);

            if (vehicle is null || vehicle.Id != vehicleId)
            {
                throw new NotFoundException("Vehicle not found");
            }
            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
            return vehicleDto;
        }
    }
}
