
using Fintech.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Fintech.Domain.Models
{
    public class Dashboard 
    {
        [Key]
        public int DashboardId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
