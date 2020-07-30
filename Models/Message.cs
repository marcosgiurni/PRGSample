using System.ComponentModel.DataAnnotations;

namespace PRGSample.Models
{
    public class Message
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(10)]
        public string Content { get; set; }
    }
}