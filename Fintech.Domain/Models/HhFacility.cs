using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class HhFacility : AccountBase
    {
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
