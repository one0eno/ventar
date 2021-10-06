using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaApi.Models;
using WSVentaApi.Models.Request;
using WSVentaApi.Models.Response;
using WSVentaApi.Services;

namespace WSVentaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {

        private IVentaService _venta;

        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add( VentaRequest model )
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _venta.Add(model);

                //var venta = new VentaService();
                //venta.Add(model);
                respuesta.Succes = 1;
                respuesta.Mensaje = "La venta se ha realizado con exito";

            }
            catch (Exception ex)
            {
                respuesta.Succes = 0;
                respuesta.Data = null;
                respuesta.Mensaje = ex.Message;
                return BadRequest(respuesta);
            }

            return Ok(respuesta);

        }
    }
}
