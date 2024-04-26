using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Responses
{
    public class LoginResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
        public string? RefereshToken { get; set; }
    }
}
