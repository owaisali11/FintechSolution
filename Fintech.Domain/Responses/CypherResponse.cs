﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Responses
{
    public class CypherResponse
    {
        public bool Status {  get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
    }
}
