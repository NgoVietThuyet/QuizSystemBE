using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizSystemApi.Models
{
    public class Option
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Content { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;

        // Foreign Key liên kết với bảng Question
        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}