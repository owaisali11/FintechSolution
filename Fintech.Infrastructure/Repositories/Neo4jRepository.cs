
using Fintech.Application.Repositories;
using Fintech.Domain.Responses;
using Microsoft.Extensions.Configuration;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Infrastructure.Repositories
{
    public class Neo4jRepository : INeo4jRepository
    {
        private readonly IDriver _driver;
        public Neo4jRepository(IConfiguration config)
        {
            var uri = config["Neo4j:Uri"];
            var username = config["Neo4j:Username"];
            var password = config["Neo4j:Password"];
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
        }
        public async Task<string> RunQueryAsync(string cypherQuery)
        {
            if (String.IsNullOrWhiteSpace(cypherQuery))
            {
                /*return new Response
                {
                    Message = "Kindly provide cypher query",
                    Status = false,
                };*/
                return null;
            }
            await using var session = _driver.AsyncSession();
            var greeting = await session.WriteTransactionAsync(
                async tx =>
                {
                    var result = await tx.RunAsync(cypherQuery);

                    // Process the result and return a string if needed
                    // For example, return the count of nodes returned by the query
                    var record = await result.SingleAsync();
                    return record[0].As<string>();
                });

            /*return new Response
            {
                Message = greeting,
                Status = true,
            };*/
            return greeting;
        }
    }
}
