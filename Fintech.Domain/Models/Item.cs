
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Item 
    {
        [Key]
        public int ItemId { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Field { get; set; }

    }
}
