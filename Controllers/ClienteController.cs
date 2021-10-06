using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaApi.Models;
using WSVentaApi.Models.Response;
using WSVentaApi.Models.Request;
using Microsoft.AspNetCore.Authorization;

namespace WSVentaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {

            Respuesta response = new Respuesta();
          
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {

                    var ls = db.Clientes.ToList().OrderByDescending(d => d.Id).ToList();
                    response.Succes = 1;
                    response.Data = ls;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                return BadRequest(response);

            }

            return Ok(response);

        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {

            Respuesta response = new Respuesta();
           
            try {
                using (VentaRealContext db = new VentaRealContext()) {

                    Cliente cliente = new Cliente();
                    cliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    response.Succes = 1;
                    response.Mensaje = "Se ha realizado la inserción correctamente";
                    response.Data = cliente;
                }
            }
            catch (Exception ex) {

                response.Succes = 1;
                response.Mensaje = ex.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {

            Respuesta response = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {

                    Cliente cliente = db.Clientes.Find(oModel.Id);

                    //db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    db.Entry(cliente).CurrentValues.SetValues(oModel);

                    db.SaveChanges();

                    response.Succes = 1;
                    response.Mensaje = "Se ha realizado la modificacion correctamente";
                    
                }
            }
            catch (Exception ex)
            {

                response.Succes = 1;
                response.Mensaje = ex.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {

            Respuesta response = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {

                    Cliente cliente = db.Clientes.Find(Id);

                    if (cliente == null)
                    {
                        response.Succes = 1;
                        response.Mensaje = "No se ha encontrado cliente con id " + Id;
                        response.Data = cliente;
                        return NotFound(response);
                    }
                    

                    cliente.Activo = false;
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                    //db.Remove(cliente);


                    response.Succes = 1;
                    response.Mensaje = "Se ha realizado la eliminación de cliente";
                    response.Data = cliente;

                }
            }
            catch (Exception ex)
            {

                response.Succes = 1;
                response.Mensaje = ex.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

