using Interview.Constants.Enums;
using Interview.Database.Configuration;
using Interview.Models;

namespace Interview.Utilities.FakeGenerators
{
    public class QuestionnaireGenerator
    {
        private CommandCenterContext _context;

        public QuestionnaireGenerator(CommandCenterContext context)
        {
            _context = context;
        }
        public Questionnaire CreateFakeQuestionnaire()
        {
            Random random = new Random();
            Questionnaire questionnaire = new Questionnaire();

            questionnaire.Id = random.Next() % 100;
            questionnaire.Title = "پرسشنامه";

            questionnaire.Questions.Add(
            new Question()
            {
                Id = random.Next() % 100,
                Caption = "شماره تلفن همراه جایگزین را وارد کنید.",
                QuestionType = QuestionType.PhoneNumber,
                Choices = new List<Choice>()
                {
                    new Choice() { Id = random.Next() % 100 , Caption = "شماره تلفن همراه" }
                }
            });


            List<Choice> cities = _context.Cities.Select(x => new Choice() { Id = x.Id, Caption = x.Name }).ToList();
            List<Choice> provinces = _context.Provinces.Select(x => new Choice() { Id = x.Id, Caption = x.Name }).ToList();


            questionnaire.Questions.Add(
            new Question()
            {
                Id = random.Next() % 100,
                Caption = "استان محل سکونت را انتخاب کنید.",
                QuestionType = QuestionType.SingleSelectDropDown,
                Choices = provinces
            });

            questionnaire.Questions.Add(
            new Question()
            {
                Id = random.Next() % 100,
                Caption = "شهر محل سکونت را انتخاب کنید.",
                QuestionType = QuestionType.SingleSelectDropDown,
                Choices = cities
            });



            questionnaire.Questions.Add(
            new Question()
            {
                Id = random.Next() % 100,
                QuestionType = QuestionType.SimpleText,
                Caption = "دلیل مراجعه شما به نمایندگی چه بوده؟",
            });

            return questionnaire;
        }
    }
}
