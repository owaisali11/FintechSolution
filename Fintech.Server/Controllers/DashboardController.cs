using Azure.Core;
using Fintech.Application.Repositories;
using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api;
using Microsoft.Rest;


namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _repository;
        public DashboardController(IDashboardRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddDashboardDetails(Dashboard dashboardModel)
        {
            if (dashboardModel == null)
            {
                return BadRequest("Model is Empty");
            }
            await _repository.AddDashboardDetails(dashboardModel);
            return Ok();
        }
        [HttpGet("GetAllDetails")]
        public async Task<IActionResult> GetAllDashboardDetails()
        {
            try
            {
                var res = await _repository.GetDashboardDetails();
                if(res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }

        }

        [HttpGet("GetDetailsByName")]
       
        public async Task<IActionResult> GetPowerBIDashboard(string Dashboardtitle)
        {
            if (string.IsNullOrEmpty(Dashboardtitle))
            {
                return BadRequest("Please Enter title");
            }
            var res = await _repository.GetDashboardDetailsByName(Dashboardtitle);
            var details =  res.dashboards;
            var embedUrl =  details[0].Url;

           // var powerBIClient = new PowerBIClient(new TokenCredentials("your-access-token"));

           //var embedUrl = "https://app.powerbi.com/reportEmbed?reportId=09fcfbe6-04b0-4b38-a393-9abf47a1d19f&autoAuth=true&ctid=a1e3cc4f-47e2-4e32-a7a1-5b14136b160b";

            // Construct the HTML content with the embed iframe
            var embedCode = $"<iframe width=\"800\" height=\"600\" src=\"{embedUrl}\"></iframe>";
            //var htmlContent = $"<html><head><title>Power BI Dashboard</title></head><body>{embedCode}</body></html>";

            // Return the HTML content
            return Content(embedCode);
        }
    }
}
