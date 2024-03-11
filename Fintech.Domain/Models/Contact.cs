
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Contact 
    {
        [Key]
        public int ContactId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Query { get; set; }
        [MaxLength(11)]
        public string? Phone { get; set; }

    }
}
