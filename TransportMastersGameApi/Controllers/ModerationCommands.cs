using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/moderationCommands")]
    [ApiController]
    public class ModerationCommands : ControllerBase
    {
        private IModerationCommands _moderationCommands;

        public ModerationCommands(IModerationCommands moderationCommands)
        {
            _moderationCommands = moderationCommands;
        }

        [HttpPost("addCargos")]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Post()
        {
            _moderationCommands.CargoCreate();
            return Ok();
        }
        [HttpPost("AddVehicle")]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult AddVehicleToMarket()
        {
            _moderationCommands.AddVehicle();
            return Ok();
        }
        [HttpPost("AddDriver")]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult AddDriver()
        {
            _moderationCommands.AddDriver();
            return Ok();
        }
    }
}
