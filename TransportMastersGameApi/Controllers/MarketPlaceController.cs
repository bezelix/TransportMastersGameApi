using FirstStepsDotNet.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/marketplace")]
    [ApiController]
    public class MarketPlaceController : ControllerBase
    {
        IMarketplaceService _marketplaceService;
        public MarketPlaceController(IMarketplaceService marketplaceService)
        {
            _marketplaceService = marketplaceService;
        }

        [HttpPost("addBid")]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Post([FromBody] Bid bidObject)
        {
            if (_marketplaceService.AddBid(bidObject)) 
            {
                return Ok();
            }
            else
            {
                throw new BadRequestExceprion("Not enough money");
            }
            
        }
        [HttpGet("getBidByVehicleId/{_vehicleId}")]

        public ActionResult<List<Bid>> GetUserByEmail([FromRoute] int _vehicleId)
        {
            List<Bid> _bid = _marketplaceService.GetBidByVehicleId(_vehicleId);
            return Ok(_bid);
        }
    }
}
