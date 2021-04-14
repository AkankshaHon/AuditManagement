using AuthorizationService.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;
        public TokenController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [HttpGet]
        public IActionResult GenerateJSONWebToken()
        {
            string token = _authProvider.GetJsonWebToken();
            if (token == null)
            {
                return BadRequest(token);
            }
            else
            {
                return Ok(token);
            }
        }
    }
}
