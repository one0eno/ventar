using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaApi.Models.Request;

namespace WSVentaApi.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest model);

    }
}
