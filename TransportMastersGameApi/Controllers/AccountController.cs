using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;
using TransportMastersGameApi.Services;

namespace TransportMastersGameApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _AccountService;

        public AccountController(IAccountService accountService)
        {
            _AccountService = accountService;
        }

        [HttpPost("register")]

        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _AccountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]

        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _AccountService.GenerateJwt(dto);
            return Ok(token);
        }
        //[HttpPost("role")]

        //public ActionResult AddRole([FromRoute] string role)
        //{
        //    _AccountService.AddRole(role);
        //    return Ok();
        //}

    }
}
