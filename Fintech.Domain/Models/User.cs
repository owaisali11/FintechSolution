using Fintech.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Fintech.Domain.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } 
        public string? Organization { get; set; }
        public string? Field { get; set; }
    }
}
