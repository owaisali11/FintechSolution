﻿using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Weight : AccountBase
    {
        public float Value { get; set; }
        public int CodeId { get; set; }
    }
}