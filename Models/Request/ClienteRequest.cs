
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVentaApi.Models.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool activo { get; set; }
    }
}
