
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Demographics 
    {
        [Key]
        public int DemographicId { get; set; }
        public string? Population { get; set; }
        public float Area { get; set; }
        public float Income { get; set; }   
        public float HousingUnits { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; } 
    }
}
