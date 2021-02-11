using System;
using System.Collections.Generic;
using System.Text;

namespace REXELPAY.Repository.Jwt.Repository.Interface
{
    public interface IJwtRepository
    {
        string GenerateJWTTokenAsync();
    }
}
