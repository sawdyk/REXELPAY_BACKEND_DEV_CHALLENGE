using System;
using System.Collections.Generic;
using System.Text;

namespace REXELPAY.Models.ResponseModels
{
    public class UserAuthResponseModel : GenericResponseModel
    {
        public string Token { get; set; }
    }
}
