using Fintech.Application.Services.Interface;
using Fintech.Domain.Dtos;
using Fintech.Domain.Responses;
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
        [HttpPost("Register")]
        public async Task<IActionResult> SignUp(Register model)
        {
            if (model == null)
            {
                return BadRequest("Model is empty");
            }
            var result = await _authenticationService.Register(model);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(Login loginModel)
        {
            if(loginModel == null)
            {
                return BadRequest("Model is Empty");
            }
            var res = await _authenticationService.SignInAsync(loginModel);
            return Ok(res);
        }
    }
}
