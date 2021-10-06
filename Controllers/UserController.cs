using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaApi.Models.Request;
using WSVentaApi.Models.Response;
using WSVentaApi.Services;

namespace WSVentaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta response = new Respuesta();

            var userresponse = _userService.Auth(model);
            if (userresponse == null)
            {
                response.Succes = 0;
                response.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(response);
            }

            response.Succes = 1;
            response.Data = userresponse;
            return Ok(response);
        }
    }
}
