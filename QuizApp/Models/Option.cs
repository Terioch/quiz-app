using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Option
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public bool IsCorrect { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

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
