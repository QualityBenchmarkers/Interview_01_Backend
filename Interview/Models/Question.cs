using Interview.Constants.Enums;

namespace Interview.Models
{
    public class Question
    {   
        public long Id { get; set; }

        public int QuestionNumber { get; set; }

        public string? Caption { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Choice> Choices { get; set; } = new();
    }
}
