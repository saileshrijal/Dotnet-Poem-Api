using System.ComponentModel.DataAnnotations;

namespace PoemAPI.Models
{
    public class Poem
    {
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}