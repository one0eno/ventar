using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVentaApi.Models.Response
{
    public class Respuesta
    {
        public int Succes { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta() {
            this.Succes = 0;
        }
    }
}
