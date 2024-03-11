
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Faq 
    {
        [Key]
        public int FaqId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}
