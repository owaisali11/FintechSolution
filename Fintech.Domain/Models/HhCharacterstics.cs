using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class HhCharacterstics
    {
        public Type? hhCode { get; set; }
        public Type? Individual { get; set; }
        public Type? Earners { get; set; }
        public Type? age_1_5 { get; set; }
        public Type? age_6_17 { get; set; }
        public Type? age_18_60 { get; set; }
        public Type? age_60 { get; set; }
        public Type? MaxEducation { get; set; }
        public Type? FemaleEducation { get; set; }
        public Type? MaleEducation { get; set; }
        public Type? College { get; set; }
        public Type? Nuclear { get; set; }
        public Type? Joint { get; set; }
        public int Extended { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; }
    }
}
