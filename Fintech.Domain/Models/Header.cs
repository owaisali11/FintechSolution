
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Header
    {
        [Key]
        public int HeaderId { get; set; }
        public string? Name { get; set; }
        public string? Page { get; set; }
    }
}
