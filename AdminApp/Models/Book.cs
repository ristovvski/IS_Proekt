using System.ComponentModel.DataAnnotations;

namespace AdminApp.Models
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}
