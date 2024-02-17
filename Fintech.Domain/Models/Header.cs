using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Header : AccountBase
    {
        public string? Name { get; set; }
        public string? Page { get; set; }
    }
}
