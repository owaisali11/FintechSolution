
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Report 
    {
        [Key]
        public int ReportId { get; set; }
        public string? Document { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
