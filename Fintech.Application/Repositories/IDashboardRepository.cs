using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Repositories
{
    public interface IDashboardRepository
    {
        Task<DashboardResponse> AddDashboardDetails(Dashboard dashboard);

        Task<DashboardResponse> GetDashboardDetailsByName(string title);
        Task<DashboardResponse> GetDashboardDetails();
    }
}
