using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Finance : AccountBase
    {
        public Type? Income { get; set; }
        public Type? Remittance { get; set; }
        public Type? Asset { get; set; }
        public Type? Salary { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; }
    }
}
