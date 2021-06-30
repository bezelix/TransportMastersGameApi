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
    [Route("api/destination")]
    [ApiController]
    [Authorize]
    public class DestinationController : ControllerBase
    {
        private IDestinationService _IDestinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _IDestinationService = destinationService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Post([FromBody] CreateDestinationDto dto)
        {
            var newDestination = _IDestinationService.Create(dto);
            //return Created($"/api/user/{userId}/delivery/{newDelivery}", null);
            return Ok(newDestination);
        }

        [HttpGet("{destinationId}")]

        public ActionResult<DeliveryDto> Get([FromRoute] int destinationId)
        {
            DestinationDto destination = _IDestinationService.GetById(destinationId);
            return Ok(destination);
        }

        [HttpGet]
        public ActionResult<DeliveryDto> GetAll()
        {
            var destination = _IDestinationService.GetAllDestinations();
            return Ok(destination);
        }

        [HttpDelete("{destinationId}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult<DestinationDto> Delete([FromRoute] int destinationId)
        {
            _IDestinationService.Delete(destinationId);
            return NoContent();
        }
    }
}
