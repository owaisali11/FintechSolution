
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Weight 
    {
        [Key]
        public int Psu { get; set; }
        public float Value { get; set; }
        public int CodeId { get; set; }
    }
}
