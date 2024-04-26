using Fintech.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Neo4jController : ControllerBase
    {
        private readonly INeo4jRepository _neo4JRepository;
      
        public Neo4jController(INeo4jRepository neo4JRepository)
        {
            _neo4JRepository = neo4JRepository;
        }
        [HttpGet("CypherQuery")]
        public async Task<IActionResult> Get(string cypherQuery)
        {
            var result = await _neo4JRepository.RunQueryAsync(cypherQuery);
            return Ok(result);
        }
    }
}
