using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REXELPAY.Models.RequestModels;
using REXELPAY.Repository.Multiples.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REXELPAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplesController : ControllerBase
    {
        private readonly IMultiplesRepository _multiplesRepository;

        public MultiplesController(IMultiplesRepository multiplesRepository, ILogger<MultiplesController> logger)
        {
            _multiplesRepository = multiplesRepository;

        }

        [HttpPost("findMultiples")]
        public async Task<IActionResult> findMultiplesAsync(MultipleRequestModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _multiplesRepository.findMultiplesAsync(obj);

            return Ok(result);
        }
    }
}
