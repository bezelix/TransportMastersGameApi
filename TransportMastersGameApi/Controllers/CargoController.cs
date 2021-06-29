using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/cargo")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private CargoService _cargoService;

        public CargoController(CargoService cargoService)
        {
            _cargoService = cargoService;
        }

    }
}
