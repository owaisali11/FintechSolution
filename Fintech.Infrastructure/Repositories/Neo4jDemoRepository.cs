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
    public class Neo4jDemoRepository : INeo4jDemoRepository
    {
        private readonly IDriver _driver;
        public Neo4jDemoRepository(IConfiguration config)
        {
            var uri = config["DemoNeo4j:Uri"];
            var username = config["DemoNeo4j:Username"];
            var password = config["DemoNeo4j:Password"];
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
        }
        public async Task<CypherResponse> RunQueryDemoAsync(string fullcypherQuery)
        {
            if (String.IsNullOrWhiteSpace(fullcypherQuery))
            {
                return new CypherResponse
                {
                    Message = "Kindly provide your cypher query",
                    Status = false,
                };
              
            }
            string cypherQuery = GetCypherQueryFromFullQuery(fullcypherQuery);

            await using var session = _driver.AsyncSession();
            var greeting = await session.ExecuteWriteAsync(
                 async tx =>
                 {
                     var result = await tx.RunAsync(cypherQuery);

                     var records = await result.ToListAsync();
                     return records.Select(record =>
                     record.Keys.ToDictionary(key => key, key => record[key])
                 ).ToList();
                 });
            if (greeting == null)
            {
                return new CypherResponse
                {
                    Status = false,
                    Message = "Answer Return is 0"
                };
            }
            if (greeting.Count >= 2)
            {
                // Process results differently if there are more than 2 records
                string detailedResponse = "\n";
                foreach (var record in greeting)
                {
                    detailedResponse += FormatResult(record) +","+ "\n";
                }
                string extractedStartingResponsee = ExtractStartingResponse(fullcypherQuery);
                string resultt = $"{extractedStartingResponsee} {detailedResponse}";
                return new CypherResponse
                {
                    Status = true,
                    Message = "Successful",
                    Data = resultt.Trim()
                };
            }
            else if (greeting.Count == 1)
            {
                var singleRecord = greeting.First();
                var singleValue = singleRecord.Values.First();
                string extractedStartingResponse = ExtractStartingResponse(fullcypherQuery);
                string extractedEndingResponse = ExtractEndingResponse(fullcypherQuery);
                string result = $"{extractedStartingResponse} {singleValue} {extractedEndingResponse}";

                return new CypherResponse
                {
                    Status = true,
                    Message = "Successfull",
                    Data = result
                };
            }
            return new CypherResponse
            {
                Status = false,
                Message = "Sorry I can't help you with this"
            };
        }
        private string GetCypherQueryFromFullQuery(string fullQuery)
        {
            // Assuming the Cypher query always starts with "```cypher" and ends with "```"
            int startIndex = fullQuery.IndexOf("```cypher") + "```cypher".Length;
            int endIndex = fullQuery.LastIndexOf("```");

            if (startIndex == -1 || endIndex == -1 || startIndex >= endIndex)
            {
                return null;
            }

            return fullQuery.Substring(startIndex, endIndex - startIndex).Trim();
        }
        private string ExtractStartingResponse(string fullQuery)
        {
            int startIndex = fullQuery.IndexOf("*Text to append to the answer:*");
            if (startIndex == -1)
            {
                return null;
            }

            int responseStartIndex = startIndex + "*Text to append to the answer:*".Length;
            int responseEndIndex = fullQuery.IndexOf("*", responseStartIndex);
            if (responseEndIndex == -1)
            {
                return null;
            }

            string textToAppend = fullQuery.Substring(responseStartIndex, responseEndIndex - responseStartIndex).Trim();
            return textToAppend;
        }
        private string ExtractEndingResponse(string fullQuery)
        {
            string cleanResponse = System.Text.RegularExpressions.Regex.Replace(fullQuery, @"\{.*?\}", "{}");
            string newResponse = cleanResponse.Trim();
            int startIndex = newResponse.IndexOf("*{}*");
            if (startIndex == -1)
            {
                return null;
            }
            int responseStartIndex = startIndex + "*{}*".Length;
            string textAfterPlaceholder = newResponse.Substring(responseStartIndex).Trim();
            return textAfterPlaceholder;
        }
        private string FormatResult(Dictionary<string, object> record)
        {
            // Customize this method to format the result as needed
            return string.Join(", ", record.Select(kvp => $"{kvp.Value}"));
        }
    }
}
