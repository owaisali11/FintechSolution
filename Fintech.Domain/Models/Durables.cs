using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Durables : AccountBase
    {
        public bool Car { get; set; }
        public bool Ac { get; set; }
        public bool Cooler { get; set; }
        public bool Tractor { get; set; }
        public bool Fridge { get; set; }
        public bool Mobile { get; set; }
        public bool Internet { get; set; }
        public bool Laptop { get; set; }

        public int CoderId { get; set; }
        public Code? code { get; set; }
    }
}
