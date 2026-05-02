using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuizSystemApi.Models
{
    public enum UserRole { STUDENT, TEACHER, ADMIN }

    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Required, MaxLength(255)]
        [JsonIgnore] // Ẩn password khi trả về JSON cho React
        public string PasswordHash { get; set; } = string.Empty;
        
        public UserRole Role { get; set; } = UserRole.STUDENT;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property (1 User - N ExamResults)
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}