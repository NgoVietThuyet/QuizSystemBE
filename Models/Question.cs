using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizSystemApi.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        public string? Explanation { get; set; }

        // Foreign Key
        [ForeignKey("Exam")]
        public Guid ExamId { get; set; }
        public Exam? Exam { get; set; }

        // Navigation property
        public ICollection<Option>? Options { get; set; }
    }
}