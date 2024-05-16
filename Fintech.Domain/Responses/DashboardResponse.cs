using Fintech.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Responses
{
    public class DashboardResponse
    {
        public Boolean Status { get; set; }
        public string? Message {  get; set; }
        public List<Dashboard>? dashboards { get; set; }
    }
}
