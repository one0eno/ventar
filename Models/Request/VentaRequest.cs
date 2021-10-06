using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSVentaApi.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1,double.MaxValue, ErrorMessage ="El valor del idcliente ha de ser mayor a 0")]
        [ExisteCliente(ErrorMessage ="El idcliente no existe")]
        public int IdCliente { get; set; }

        
        public decimal Total { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Debe de haber al menos un concepto")]
        public List<Concepto> Conceptos { get; set; }

        public VentaRequest()
        {
            this.Conceptos = new List<Concepto>();
        }
    }

    public class Concepto { 
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int  IdProducto { get; set; }
    }

    #region Validaciones
    public class ExisteClienteAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idCliente = (int)value;
            using (var db = new Models.VentaRealContext())
            {
                if (db.Clientes.Find(idCliente) == null)
                    return false;

            }
            return true;
        }
    }
    #endregion
}
