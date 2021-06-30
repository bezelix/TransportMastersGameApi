using AutoMapper;
using FirstStepsDotNet.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public class DriverService : IDriverService
    {
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<DriverService> _logger;
        public DriverService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<DriverService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public object Create(CreateDriverDto dto)
        {
            var driver = _mapper.Map<Driver>(dto);
            _dbContext.Drivers.Add(driver);
            _dbContext.SaveChanges();
            return driver.Id;
        }

        

        public object GetAllDrivers()
        {
            var drivers = _dbContext
                            .Drivers;

            var driversDtos = _mapper.Map<List<DriverDto>>(drivers);
            return driversDtos;
        }

        public DriverDto GetById(int driverId)
        {
            var driver = _dbContext
                            .Drivers
                            .FirstOrDefault(d => d.Id == driverId);

            if (driver is null || driver.Id != driverId)
            {
                throw new NotFoundException("Delivery not found");
            }
            var driverDto = _mapper.Map<DriverDto>(driver);
            return driverDto;
        }
        public void Delete(int driverId)
        {
            //_logger.LogWarning($" with Id: {id} DELETE action invoked");//loger 
            var driver = _dbContext
                            .Drivers
                            .FirstOrDefault(r => r.Id == driverId);
            if (driver is null)
                throw new NotFoundException("Driver not found");

            _dbContext.Drivers.Remove(driver);
            _dbContext.SaveChanges();
        }
    }
}
