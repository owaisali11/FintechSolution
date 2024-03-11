
using Fintech.Domain.Dtos;
using System.ComponentModel.DataAnnotations;


namespace Fintech.Domain.Models
{
    public class Article 
    {
        [Key]
        public int ArticleId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public List<Tag>? Tags { get; set; }

    }
}
