using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    //[Authorize]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _VehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _VehicleService = vehicleService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateVehicleDto dto)
        {
            var newVehicle = _VehicleService.Create(dto);
            //return Created($"/api/user/{userId}/delivery/{newDelivery}", null);
            return Ok(newVehicle);
        }

        [HttpGet("{vehicleId}")]

        public ActionResult<VehicleDto> Get([FromRoute] int vehicleId)
        {
            VehicleDto vehicle = _VehicleService.GetById(vehicleId);
            return Ok(vehicle);
        }

        [HttpGet]
        public ActionResult<VehicleDto> GetAll()
        {
            var vehicle = _VehicleService.GetAllVehicle();
            return Ok(vehicle);
        }
        [HttpGet("marketplace/vehicle")]
        public ActionResult<List<Vehicle>> GetAllOnMarketplace()
        {
            List<VehicleDto> vehicles = _VehicleService.GetAllOnMarketplace();
            return Ok(vehicles);
        }

        [HttpDelete("{vehicleId}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult<VehicleDto> Delete([FromRoute] int vehicleId)
        {
            _VehicleService.Delete(vehicleId);
            return NoContent();
        }

    }
}
