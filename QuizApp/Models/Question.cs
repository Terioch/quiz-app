using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Question
    {       
        public int Id { get; set; }

        public string Name { get; set; }        

        public Option OptionA { get; set; }

        public Option OptionB { get; set; }

        public Option OptionC { get; set; }

        public Option OptionD { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [NotMapped]
        public string CreatedAtString
        {
            get
            {
                return CreatedAt.ToString("dd/MM/yyyy");
            }
        }

        [NotMapped]
        public List<Option> Options
        {
            get
            {
                return new List<Option> { OptionA, OptionB, OptionC, OptionD };
            }            
        }
    }
}
