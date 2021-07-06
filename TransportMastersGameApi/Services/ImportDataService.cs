using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Services
{
    public class ImportDataService : IImportDataService
    {
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<DriverService> _logger;
        public ImportDataService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<DriverService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public object Create(LocationDataDto dto)
        {
            var location = _mapper.Map<Destination>(dto);
            _dbContext.Destinations.Add(location);
            _dbContext.SaveChanges();
            return location.Id;
        }
    }
}
