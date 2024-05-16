using Fintech.Application.Repositories;
using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using Fintech.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DashboardResponse> AddDashboardDetails(Dashboard dashboard)
        {
            if (dashboard is null)
            {
                return new DashboardResponse
                {
                    Status = false,
                    Message = "Model is null",
                    dashboards = null
                };
            }
             await _context.Dashboards.AddAsync(dashboard);
            await _context.SaveChangesAsync();
            return new DashboardResponse
            {
                Status = true,
                Message = "Details Succesfully Added",
            };
        }

        public async Task<DashboardResponse> GetDashboardDetails()
        {
            var dashboardDetails = await _context.Dashboards.ToListAsync();
            if(dashboardDetails is null)
            {
                return new DashboardResponse
                {
                    Status = false,
                    Message= "No Details Found",
                };
            }
            return new DashboardResponse
            {
                Status = true,
                dashboards = dashboardDetails,
            };
        }

        public async Task<DashboardResponse> GetDashboardDetailsByName(string title)
        {
            var dashboardTitle = await _context.Dashboards.FirstOrDefaultAsync(x => x.Title == title);
            if(dashboardTitle is null)
            {
                return new DashboardResponse
                {
                    Status = false,
                    Message = "Message Not Found",
                    dashboards = null,
                };
            }
            var dashboardDetails = await _context.Dashboards
                                            .Where(x => x.Title == title)
                                            .ToListAsync();
            return new DashboardResponse
            {
                Status = true,
                dashboards = dashboardDetails,
            };
        }
        
    }
}
