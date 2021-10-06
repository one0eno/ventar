using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaApi.Models.Request;
using WSVentaApi.Models.Response;

namespace WSVentaApi.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
