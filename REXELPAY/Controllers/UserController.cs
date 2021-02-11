using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REXELPAY.Models.RequestModels;
using REXELPAY.Repository.Users.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REXELPAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost("authenticateUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUsersAsync(AuthenticateRequestModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _usersRepository.AuthenticateUsersAsync(obj);

            return Ok(result);
        }
    }
}
