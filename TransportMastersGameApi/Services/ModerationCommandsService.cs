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

        public void CargoCreate()
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
        private VehicleTemplate GetRandomVehicleTemplate()
        {
            Random rnd = new Random();

            var vehicleTemplate = _dbContext
                            .VehicleTemplate.ToList();

            int _randomInt = rnd.Next(0, vehicleTemplate.Count);
            return vehicleTemplate[_randomInt];
        }
        private Destination GetRandomDestination()
        {
            Random rnd = new Random();

            var destinations = _dbContext
                            .Destinations.ToList();

            int _randomInt = rnd.Next(0, destinations.Count);
            return destinations[_randomInt];
        }
        public DateTime GetManufactureDate()
        {
            DateTime date3;
            Random rnd = new Random();
            int _randomInt = rnd.Next(-3600, -360);
            DateTime date2 = DateTime.Today;
            date3 = date2.AddDays(_randomInt);
            return date3;
        }
        public int GetVehicleMileage(DateTime dateTime)
        {
            DateTime date2 = DateTime.Today;
            TimeSpan result = date2 - dateTime;
            int ResultDays = result.Days;
            int totalMileage = 0;
            Random rnd = new Random();
            int _randomInt;

            for (int i = 0; i < ResultDays; i++)
            {
                _randomInt = rnd.Next(10, 500);
                totalMileage = totalMileage + _randomInt;
            }
            return totalMileage;
        }

        public int GetRandomCarCondition()
        {
            Random rnd = new Random();
            int _randomInt = rnd.Next(50, 100);
            return _randomInt;
        }

        public void AddVehicle()
        {
            for (int i = 0; i < 10; i++)
            {
                Vehicle vehicle = new Vehicle();

                VehicleTemplate vehicleTemplate = new VehicleTemplate();
                vehicleTemplate = GetRandomVehicleTemplate();
                var _date = GetManufactureDate();
                var _startLocalization = new Destination();
                _startLocalization = GetRandomDestination();

                vehicle.ManufactureDate = _date.ToString("yyyy-MM-dd HH:mm:ss");
                vehicle.VehicleMileage = GetVehicleMileage(_date);
                vehicle.ModelNameNumber = vehicleTemplate.ModelNameNumber;
                vehicle.CarManufacturerNumber = vehicleTemplate.CarManufacturerNumber;
                vehicle.Payload = vehicleTemplate.Payload;
                vehicle.Speed = vehicleTemplate.Speed;
                vehicle.StartPrice = vehicleTemplate.StartPrice;
                vehicle.CarCondition = GetRandomCarCondition();
                vehicle.Lat = _startLocalization.Lat;
                vehicle.Lon = _startLocalization.Lon;
                vehicle.OnMarket = true;
                vehicle.OfferStartTime = DateTime.Now;

                _dbContext.Vehicles.Add(vehicle);
                _dbContext.SaveChanges();
            }
        }

        public int GetRandomLevel()
        {
            Random rnd = new Random();
            int _randomInt = rnd.Next(1, 50);
            return _randomInt;
        }
        private FirstName GetRandomFirstName()
        {
            Random rnd = new Random();

            var firstName = _dbContext
                            .FirstName.ToList();

            int _randomInt = rnd.Next(0, firstName.Count);
            return firstName[_randomInt];
        }
        private LastName GetRandomLastName()
        {
            Random rnd = new Random();

            var lastName = _dbContext
                            .LastName.ToList();

            int _randomInt = rnd.Next(0, lastName.Count);
            return lastName[_randomInt];
        }
        public void AddDriver()
        {
            for (int i = 0; i < 10; i++)
            {
                Driver driver = new Driver();
                driver.FirstName = GetRandomFirstName().FirstNameValue;
                driver.LastName = GetRandomLastName().LastNameValue;
                driver.Level = GetRandomLevel();

                _dbContext.Drivers.Add(driver);
                _dbContext.SaveChanges();
            }
        }
        
        public void EverySeccondJob()
        {
            for (int i = 0; i <= 12; i++)
            {

                SaveLog();
                Task.Delay(5000).Wait();
            }
        }
        private void SaveLog()
        {
            MSQLLogs log = new MSQLLogs();

            log.LogInfo = "im working";
            log.Date = DateTime.Now;

            _dbContext.MSQLLogs.Add(log);
            _dbContext.SaveChanges();
        }
    }
}
