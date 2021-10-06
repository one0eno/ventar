using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaApi.Models;
using WSVentaApi.Models.Request;

namespace WSVentaApi.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
           
                using (VentaRealContext db = new VentaRealContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var venta = new Ventum();
                            venta.Total = model.Conceptos.Sum(o => o.Cantidad * o.PrecioUnitario);
                            venta.Fecha = DateTime.Now;
                            venta.IdCliente = model.IdCliente;
                            db.Venta.Add(venta);
                            db.SaveChanges();

                            foreach (var Modelconcepto in model.Conceptos)
                            {
                                var concept = new Models.Concepto();
                                concept.Cantidad = Modelconcepto.Cantidad;
                                concept.IdProducto = Modelconcepto.IdProducto;
                                concept.PrecioUnitario = Modelconcepto.PrecioUnitario;
                                concept.Importe = Modelconcepto.Importe;
                                concept.IdVenta = venta.Id;
                                db.Conceptos.Add(concept);
                                db.SaveChanges();
                            }

                            transaction.Commit();

                           
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error en la inserción" + ex.Message);
                        }
                    }
                }
            
        }
    }
}
