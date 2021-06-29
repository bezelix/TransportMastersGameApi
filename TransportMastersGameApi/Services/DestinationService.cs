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
    public class DestinationService : IDestinationService
    {
        private ICargoService _ICargoService;
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<DeliveryService> _logger;

        public DestinationService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<DeliveryService> logger, ICargoService cargoController)
        {
            _ICargoService = cargoController;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public object Create(CreateDestinationDto dto)
        {
            var destinations = _mapper.Map<Destination>(dto);
            _dbContext.Destinations.Add(destinations);
            _dbContext.SaveChanges();

            //should be added to improve service
            //for (int i = 0; i < 10; i++)
            //{
            //    _ICargoService.CreateRandomCargo(dto)
            //}
            return destinations.Id;
        }

        public void Delete(int destinationId)
        {
            //_logger.LogWarning($"Dish with Id: {id} DELETE action invoked");//loger 
            var destination = _dbContext
                            .Destinations
                            .FirstOrDefault(r => r.Id == destinationId);
            if (destination is null)
                throw new NotFoundException("Cargo not found");

            _dbContext.Destinations.Remove(destination);
            _dbContext.SaveChanges();
        }

        public object GetAllDestinations()
        {
            var destinations = _dbContext
                            .Cargos;

            var destinationsDtos = _mapper.Map<List<DestinationDto>>(destinations);
            return destinationsDtos;
        }

        public DestinationDto GetById(int destinationId)
        {
            var destinations = _dbContext
                            .Destinations
                            .FirstOrDefault(d => d.Id == destinationId);

            if (destinations is null || destinations.Id != destinationId)
            {
                throw new NotFoundException("Delivery not found");
            }
            var destinationsDto = _mapper.Map<DestinationDto>(destinations);
            return destinationsDto;
        }


    }
}
