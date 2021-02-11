using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using REXELPAY.DataAccess.Entities;
using REXELPAY.Helpers.Utilities;
using REXELPAY.Models.RequestModels;
using REXELPAY.Models.ResponseModels;
using REXELPAY.Repository.Jwt.Repository.Interface;
using REXELPAY.Repository.Users.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REXELPAY.Repository.Users.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ILogger<UsersRepository> _logger;
        private readonly IJwtRepository _jwtRepository;
       
        public UsersRepository(ILogger<UsersRepository> logger, IJwtRepository jwtRepository)
        {
            _logger = logger;
            _jwtRepository =  jwtRepository; 
        }

        // Users Credentials hardcoded for simplicity, will be stored in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "RexelPay", LastName = "Challenge", Username = "Backend", Password = "Developer" }
        };

        public async Task<UserAuthResponseModel> AuthenticateUsersAsync(AuthenticateRequestModel obj)
        {
            try
            {
                var user = await Task.Run(() => _users.FirstOrDefault(x => x.Username == obj.Username && x.Password == obj.Password));

                if (user != null)
                {
                    //get the jwt token generated
                    var tokenString = _jwtRepository.GenerateJWTTokenAsync();

                    //The User Information
                    var userData = new UserDataResponseModel();
                    userData.Id = user.Id;
                    userData.FirstName = user.FirstName;
                    userData.LastName = user.LastName;
                    userData.Username = user.Username;

                    return new UserAuthResponseModel { Code = System.Net.HttpStatusCode.OK, Message = "Success", Token = tokenString, Data = userData };
                }

                return new UserAuthResponseModel { Code = System.Net.HttpStatusCode.NotFound, Message = "Invalid Username/Password"};
            }
            catch (Exception exMessage)
            {
                //Logs Information
                var logInfo = new Logger(_logger);
                logInfo.logException(exMessage);

                //Returns Generic reposne to users
                return new UserAuthResponseModel { Code = System.Net.HttpStatusCode.InternalServerError, Message = "An Error Occurred" };
            }
        }
    }
}
