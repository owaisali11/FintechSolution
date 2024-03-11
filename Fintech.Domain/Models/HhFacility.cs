
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class HhFacility 
    {
        [Key]
        public int hhCode { get; set; }
        public bool BrickWall { get; set; }
        public bool RccRoof { get; set; }
        public bool FlushToilet { get; set; }
        public bool TapWater { get; set; }
        public bool Electricity { get; set; }
        public bool Gas { get; set; }

        public int CodeId { get; set; }
        public Code? code { get; set; }
    }
}
