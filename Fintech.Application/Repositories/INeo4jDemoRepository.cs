using Fintech.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Repositories
{
    public interface INeo4jDemoRepository 
    {
        Task<CypherResponse> RunQueryDemoAsync(string fullcypherQuery);
    }
}
