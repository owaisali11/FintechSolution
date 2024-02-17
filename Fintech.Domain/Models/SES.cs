using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class SES :  AccountBase
    {
        public string? Score { get; set; }
        public string? Class { get; set; }
    }
}
