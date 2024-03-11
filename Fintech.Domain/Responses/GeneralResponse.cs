using Fintech.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Responses
{
    public class GeneralResponse<T>
    {
        public bool status { get; set; }
        public List<T>? Data { get; set; }
    }
}
