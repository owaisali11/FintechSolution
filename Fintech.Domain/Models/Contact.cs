using CA.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Contact :  AccountBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Query { get; set; }
        [MaxLength(11)]
        public string? Phone { get; set; }

    }
}
