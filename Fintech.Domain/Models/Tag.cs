using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Tag : AccountBase
    {
        public string? Name { get; set; }
        public int MyProperty { get; set; }

        public Article? Article { get; set; }        
        public int ArticleId { get; set; }

    }
}
