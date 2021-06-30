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
    [Route("api/cargo")]
    [ApiController]
    [Authorize]
    public class CargoController : ControllerBase
    {
        private ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateCargoDto dto)
        {
            var newDelivery = _cargoService.Create(dto);
            return Ok();
        }

        [HttpGet("{cargoId}")]

        public ActionResult<CargoDto> Get([FromRoute] int cargoId)
        {
            CargoDto cargo = _cargoService.GetById(cargoId);
            return Ok(cargo);
        }
        [HttpGet]
        public ActionResult<CargoDto> GetAll()
        {
            var cargo = _cargoService.GetAll();
            return Ok(cargo);
        }
        [HttpDelete("{cargoId}")]
        public ActionResult<CargoDto> Delete([FromRoute] int cargoId)
        {
            _cargoService.Delete(cargoId);
            return NoContent();
        }
    }
}
