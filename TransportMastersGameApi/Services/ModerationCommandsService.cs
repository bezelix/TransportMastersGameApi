using AutoMapper;
using FirstStepsDotNet.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi.Services
{
    public class ModerationCommandsService : IModerationCommands
    {
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<ModerationCommandsService> _logger;
        public ModerationCommandsService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<ModerationCommandsService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Create()
        {
            for (int i = 0; i < 100; i++)
            {
                Cargo cargo = new Cargo();
                
                CargoTemplate cargoTemplate = new CargoTemplate();
                cargoTemplate = GetRandomTemplate();

                cargo.Name = cargoTemplate.Name;
                cargo.Price = cargoTemplate.Price;
                cargo.Description = "";
                cargo.Available = true;
                cargo.StartLocation = GetRandomDestination().Id;
                cargo.Destination = GetRandomDestination().Id;

                _dbContext.Cargos.Add(cargo);
                _dbContext.SaveChanges();
            }
        }

        private CargoTemplate GetRandomTemplate()
        {
            Random rnd = new Random();

            var _cargoTemplate = _dbContext
                            .CargoTemplate.ToList();

            int _randomInt = rnd.Next(0, _cargoTemplate.Count);
            return _cargoTemplate[_randomInt];
        }
        private Destination GetRandomDestination()
        {
            Random rnd = new Random();

            var destinations = _dbContext
                            .Destinations.ToList();
            
            int _randomInt = rnd.Next(0, destinations.Count);
            return destinations[_randomInt];
        }
    }
}
