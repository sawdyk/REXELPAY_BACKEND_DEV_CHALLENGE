using System;
using System.Collections.Generic;
using System.Text;

namespace REXELPAY.Models.ResponseModels
{
    public class GenericResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set;}
        public object Data { get; set; }
    }
}
