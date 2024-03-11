using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Domain.Dtos
{
    public class AccountBase
    {
        [Key]
        public int Id { get; set; }
    }
}
