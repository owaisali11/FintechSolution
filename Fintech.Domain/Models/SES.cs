
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class SES 
    {
        [Key]
        public int SESId { get; set; }
        public string? Score { get; set; }
        public string? Class { get; set; }
    }
}
