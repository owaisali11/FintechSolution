using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class HhCharacterstics
    {
        [Key]
        public int hhCode { get; set; }
        public string? Individual { get; set; }
        public string? Earners { get; set; }
        public string? age_1_5 { get; set; }
        public string? age_6_17 { get; set; }
        public string? age_18_60 { get; set; }
        public string? age_60 { get; set; }
        public string? MaxEducation { get; set; }
        public string? FemaleEducation { get; set; }
        public string? MaleEducation { get; set; }
        public string? College { get; set; }
        public string? Nuclear { get; set; }
        public string? Joint { get; set; }
        public int Extended { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; }
    }
}
