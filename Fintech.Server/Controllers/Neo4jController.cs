using Fintech.Application.Repositories;
using Fintech.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Neo4jController : ControllerBase
    {
        private readonly INeo4jRepository _neo4JRepository;
        private readonly INeo4jDemoRepository _neo4JDemoRepository;
        // private readonly HttpClient _httpClient;


        public Neo4jController(INeo4jRepository neo4JRepository, INeo4jDemoRepository neo4JDemoRepository)
        {
            _neo4JRepository = neo4JRepository;
            _neo4JDemoRepository = neo4JDemoRepository;
            //_httpClient = httpClientFactory.CreateClient();

        }

        [HttpPost("CypherQuery")]
        public async Task<IActionResult> Get([FromBody] CypherQueryRequest cypherRequest)
        {
            try
            {
                if (cypherRequest == null)
                {
                    return BadRequest("Invalid request body");
                }
                var result = await _neo4JRepository.RunQueryAsync(cypherRequest.CypherQuery!);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("DemoCypherQuery")]
        public async Task<IActionResult> GetCypher([FromBody] CypherQueryRequest cypherRequest)
        {
            try
            {
                if (cypherRequest == null)
                {
                    return BadRequest("Invalid request body");
                }
                var result = await _neo4JDemoRepository.RunQueryDemoAsync(cypherRequest.CypherQuery!);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
