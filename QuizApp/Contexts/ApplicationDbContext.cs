using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }
    }
}
