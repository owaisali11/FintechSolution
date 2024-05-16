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
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.Register(model);
                if (!result.Status)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            return BadRequest(new Response { Message = "Some properties are not valid.", Status = false });
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
