using AuthorizationService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public TokenController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpGet]
        public IActionResult GenerateJSONWebToken()
        {
            string token = _authRepo.GenerateJWT(); // _authProvider.GetJsonWebToken();
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
