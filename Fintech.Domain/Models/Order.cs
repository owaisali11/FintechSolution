using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Order :  AccountBase
    {
        public string? Item { get; set; }
        public DateTime date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
    }
}
