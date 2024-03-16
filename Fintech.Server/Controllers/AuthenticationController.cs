using Fintech.Application.Services.Interface;
using Fintech.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]

        public async Task<IActionResult> SignUp(Register model)
        {
            var result = _authenticationService.Register(model);

            if(model == null)
            {
                return BadRequest("Model is empty");
            }
            return Ok(result);
        }
    }
}
