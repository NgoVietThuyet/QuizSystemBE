using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizSystemApi.Models
{
    public class Exam
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required, MaxLength(255)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public int DurationMinutes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        public Subject? Subject { get; set; }

        // Navigation properties
        public ICollection<Question>? Questions { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}