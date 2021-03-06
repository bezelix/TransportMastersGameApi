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
    public class CargoService : ICargoService
    {
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<DeliveryService> _logger;

        public CargoService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<DeliveryService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void ChangeAvailable(int cargoId)
        {
            var cargo = _dbContext
                                        .Cargos
                                        .FirstOrDefault(r => r.Id == cargoId);
            if (cargo is null)
            {
                throw new NotFoundException("Cargo not found");
            }
            else
            {
                cargo.Available = false;
            }
            _dbContext.Cargos.Update(cargo);
            _dbContext.SaveChanges();
        }

        public object Create(CreateCargoDto dto)
        {
            var cargo = _mapper.Map<Cargo>(dto);
            _dbContext.Cargos.Add(cargo);
            _dbContext.SaveChanges();
            return cargo.Id;
        }

        public void CreateRandomCargo(CreateDestinationDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int cargoId)
        {
            //_logger.LogWarning($"Dish with Id: {id} DELETE action invoked");//loger 
            var cargo = _dbContext
                            .Cargos
                            .FirstOrDefault(r => r.Id == cargoId);
            if (cargo is null)
                throw new NotFoundException("Cargo not found");

            _dbContext.Cargos.Remove(cargo);
            _dbContext.SaveChanges();
        }

        public object GetAll()
        {
            var cargos = _dbContext
                            .Cargos;

            var cargosDtos = _mapper.Map<List<CargoDto>>(cargos);
            return cargosDtos;
        }

        public CargoDto GetById(int cargoId)
        {
            var cargo = _dbContext
                            .Deliveries
                            .FirstOrDefault(d => d.Id == cargoId);

            if (cargo is null || cargo.User != cargoId)
            {
                throw new NotFoundException("Delivery not found");
            }
            var cargoDto = _mapper.Map<CargoDto>(cargo);
            return cargoDto;
        }
    }
}
