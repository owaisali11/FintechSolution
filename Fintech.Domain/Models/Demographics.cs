using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Demographics : AccountBase
    {
        public string? Population { get; set; }
        public float Area { get; set; }
        public float Income { get; set; }   
        public float HousingUnits { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; } 
    }
}
