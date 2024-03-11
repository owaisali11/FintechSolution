﻿
using Fintech.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Models
{
    public class Tag 
    {
        [Key]
        public int TagId { get; set; }
        public string? Name { get; set; }
        public int MyProperty { get; set; }

        public Article? Article { get; set; }        
        public int ArticleId { get; set; }

    }
}
