using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizSystemApi.Models
{
    public class ExamResult
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public decimal Score { get; set; }
        
        [Required]
        public int TotalCorrect { get; set; }
        
        [Required]
        public int TotalQuestions { get; set; }
        
        [Required]
        public int TimeTakenSeconds { get; set; }
        
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Exam")]
        public Guid ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}