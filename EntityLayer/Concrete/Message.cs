using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        [MaxLength(200)]
        public string Subject { get; set; } 

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } 
    }
}
