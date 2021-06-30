using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/driver")]
    [ApiController]
    [Authorize]
    public class DriverController : ControllerBase
    {
        private IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateDriverDto dto)
        {
            var newdriver = _driverService.Create(dto);
            //return Created($"/api/user/{userId}/delivery/{newDelivery}", null);
            return Ok(newdriver);
        }

        [HttpGet("{driverId}")]

        public ActionResult<DriverDto> Get([FromRoute] int driverId)
        {
            DriverDto driver = _driverService.GetById(driverId);
            return Ok(driver);
        }

        [HttpGet]
        public ActionResult<DriverDto> GetAll()
        {
            var driver = _driverService.GetAllDrivers();
            return Ok(driver);
        }

        [HttpDelete("{driverId}")]
        public ActionResult<DriverDto> Delete([FromRoute] int driverId)
        {
            _driverService.Delete(driverId);
            return NoContent();
        }

    }
}
