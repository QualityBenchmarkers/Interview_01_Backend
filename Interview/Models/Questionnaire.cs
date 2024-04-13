namespace Interview.Models
{
    public class Questionnaire
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public List<Question> Questions { get; set; } = new();
    }
}
