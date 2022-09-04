using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Question
    {       
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public Option OptionA { get; set; }

        [NotMapped]
        public Option OptionB { get; set; }

        [NotMapped]
        public Option OptionC { get; set; }

        [NotMapped]
        public Option OptionD { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual List<Option> Options { get; set; } = new List<Option>();

        [NotMapped]
        public string CreatedAtString
        {
            get
            {
                return CreatedAt.ToString("dd/MM/yyyy");
            }
        }

        /*[NotMapped]
        public List<Option> Options
        {
            get
            {
                return new List<Option> { OptionA, OptionB, OptionC, OptionD };
            }            
        }*/
    }
}
