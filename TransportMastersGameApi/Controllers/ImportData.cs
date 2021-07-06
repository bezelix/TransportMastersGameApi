using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/importData")]
    [ApiController]
    public class ImportData : ControllerBase
    {
        private IImportDataService _importDataService;

        public ImportData(IImportDataService importDataService)
        {
            _importDataService = importDataService;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Post([FromBody] LocationDataDto dto)
        {
            var newLocation = _importDataService.Create(dto);
            //return Created($"/api/user/{userId}/delivery/{newDelivery}", null);
            return Ok();
        }
    }
}
