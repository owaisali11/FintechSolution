using Fintech.Application.Services.Interface;
using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFaqService _faqService;
        public HomeController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]

        public async Task<ActionResult<GeneralResponse<Faq>>> GetAllFaq()
        {
            try
            {
                var result = await _faqService.GetAllFaq();

                if(result == null)
                {
                    return NotFound(new GeneralResponse<Faq>
                    {
                        status = false,
                        Data = null,
                    });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponse<Faq>
                {
                    status = false,
                    Data = null,
                });
            }
        }
    }
}
