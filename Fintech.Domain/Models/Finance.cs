
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Finance
    {
        [Key]
        public int FinanceId { get; set; }
        public string? Income { get; set; }
        public string? Remittance { get; set; }
        public string? Asset { get; set; }
        public string? Salary { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; }
    }
}
