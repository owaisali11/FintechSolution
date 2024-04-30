using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api;
using Microsoft.Rest;


namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerBiController : ControllerBase
    {
        [HttpGet]
        [Route("dashboard")]
        public async Task<IActionResult> GetPowerBIDashboard()
        {
            // Initialize the Power BI client
            var powerBIClient = new PowerBIClient(new TokenCredentials("your-access-token"));

            // Get embed URL for the Power BI dashboard
            //var dashboard = await powerBIClient.Dashboards.GetDashboardInGroupAsync("your-group-id", "your-dashboard-id");
            var embedUrl = "https://app.powerbi.com/reportEmbed?reportId=09fcfbe6-04b0-4b38-a393-9abf47a1d19f&autoAuth=true&ctid=a1e3cc4f-47e2-4e32-a7a1-5b14136b160b";

            // Construct the HTML content with the embed iframe
            var embedCode = $"<iframe width=\"800\" height=\"600\" src=\"{embedUrl}\"></iframe>";
            var htmlContent = $"<html><head><title>Power BI Dashboard</title></head><body>{embedCode}</body></html>";

            // Return the HTML content
            return Content(htmlContent, "text/html");
        }
    }
}
