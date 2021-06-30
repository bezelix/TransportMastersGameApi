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
    [Route("api/user/{userId}/delivery")]
    [ApiController]
    [Authorize]
    public class DeliveryController : ControllerBase
    {
        private IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int userId, [FromBody] CreateDeliveryDto dto) 
        {
            var newDelivery = _deliveryService.Create(userId, dto);
            return Created($"/api/user/{userId}/delivery/{newDelivery}", null);
        }

        [HttpGet("{deliveryId}")]

        public ActionResult<DeliveryDto> Get([FromRoute] int userId, [FromRoute] int deliveryId)
        {
            DeliveryDto delivery = _deliveryService.GetById(userId, deliveryId);
            return Ok(delivery);
        }
        [HttpGet]
        public ActionResult<DeliveryDto> GetAll([FromRoute] int userId)
        {
            var delivery = _deliveryService.GetAllUserDelivery(userId);
            return Ok(delivery);
        }

       
        [HttpDelete]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult<DeliveryDto> DeleteAll([FromRoute] int userId)
        {
            _deliveryService.DeleteAll(userId);
            return NoContent();
        }
        [HttpDelete("{deliveryId}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult<DeliveryDto> Delete([FromRoute] int deliveryId)
        {
            _deliveryService.Delete(deliveryId);
            return NoContent();
        }
    }
}
