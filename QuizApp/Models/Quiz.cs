using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual List<Question> Questions { get; set; } = new List<Question>();

        [NotMapped]
        public string CreatedAtString
        {
            get
            {
                return CreatedAt.ToString("dd/MM/yyyy");
            }
        }
    }
}
