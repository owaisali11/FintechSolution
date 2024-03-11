
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Code
    {
        [Key]
        public int CodeId { get; set; }
        public int District { get; set; }
        public int Province { get; set; }
        public string? Name { get; set; }
        public List<Demographics>? Demographics { get; set;}
        public List<HhCharacterstics>? Characteristics { get; set; }
        public List<HhFacility>? HhFacility { get; set; }
        public List<Finance>? finances { get; set; }
        public List<Durables>? Durables { get; set; }



    }
}
