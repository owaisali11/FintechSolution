using CA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Models
{
    public class Article : AccountBase
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public List<Tag>? Tags { get; set; }

    }
}
