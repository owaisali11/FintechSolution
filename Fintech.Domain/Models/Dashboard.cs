
using Fintech.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Fintech.Domain.Models
{
    public class Dashboard 
    {
        [Key]
        public int DashboardId { get; set; }
        public string? Eframe { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

    }
}
