using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuizSystemApi.Models;

namespace QuizSystemApi.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(AppDbContext context)
        {
            context.Database.Migrate();

            var users = new[]
            {
                new User
                {
                    Name = "Thuyết",
                    Email = "admin@gmail.com",
                    PasswordHash = HashPassword("Admin@123"),
                    Role = UserRole.ADMIN,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Name = "Linh",
                    Email = "linh@gmail.com",
                    PasswordHash = HashPassword("Teacher@123"),
                    Role = UserRole.TEACHER,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Name = "Huy",
                    Email = "huy@gmail.com",
                    PasswordHash = HashPassword("Teacher@123"),
                    Role = UserRole.TEACHER,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Name = "Nam",
                    Email = "nam@gmail.com",
                    PasswordHash = HashPassword("Student@123"),
                    Role = UserRole.STUDENT,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Name = "Mai",
                    Email = "mai@gmail.com",
                    PasswordHash = HashPassword("Student@123"),
                    Role = UserRole.STUDENT,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Name = "Hoa",
                    Email = "hoa@gmail.com",
                    PasswordHash = HashPassword("Student@123"),
                    Role = UserRole.STUDENT,
                    CreatedAt = DateTime.UtcNow
                }
            };

            foreach (var user in users)
            {
                if (!context.Users.Any(u => u.Email == user.Email))
                {
                    context.Users.Add(user);
                }
            }

            context.SaveChanges();
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }
    }
}
