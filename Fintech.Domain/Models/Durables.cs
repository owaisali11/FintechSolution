
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Durables 
    {
        [Key]
        public int DurableId { get; set; }
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
