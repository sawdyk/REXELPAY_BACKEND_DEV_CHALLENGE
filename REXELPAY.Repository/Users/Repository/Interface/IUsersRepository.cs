using REXELPAY.Models.RequestModels;
using REXELPAY.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REXELPAY.Repository.Users.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<UserAuthResponseModel> AuthenticateUsersAsync(AuthenticateRequestModel obj);

    }
}
