
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Order 
    {
        [Key]
        public int OrderId { get; set; }
        public string? Item { get; set; }
        public DateTime date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
    }
}
