using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Faq : AccountBase
    {
        public string? Question { get; set; }
        public Type? Answer { get; set; }
    }
}
