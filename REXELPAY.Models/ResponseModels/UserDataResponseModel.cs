using System;
using System.Collections.Generic;
using System.Text;

namespace REXELPAY.Models.ResponseModels
{
    public class UserDataResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}
