using System.ComponentModel.DataAnnotations;

namespace QuizSystemApi.Models
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required, MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Exam>? Exams { get; set; }
        public ICollection<Document>? Documents { get; set; }
    }
}