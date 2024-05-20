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
            var questionIds = new List<long>();

            questionIds.Add(random.Next() % 100);
            questionIds.Add(random.Next() % 100);
            questionIds.Add(random.Next() % 100);
            questionIds.Add(random.Next() % 100);
            questionIds.Add(random.Next() % 100);

            Console.WriteLine(questionIds);


            Questionnaire questionnaire = new Questionnaire();


            questionnaire.Id = random.Next() % 100;
            questionnaire.Title = "پرسشنامه";

            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[0],
                QuestionNumber = 1,
                Caption = "یک یا چند تا از گزینه های زیر رو انتخاب کنید؟ تست 1",
                QuestionType = QuestionType.Checkbox,
                Choices = new List<Choice>()
                {
                   new Choice()
                   {
                       Caption = "گزینه یک",
                       Id = random.Next() %100,
                   },
                   new Choice()
                   {
                       Caption = "گزینه دو",
                       Id = random.Next() %100,
                   },
                   new Choice()
                   {
                       Caption = "گزینه 3",
                       Id = random.Next() %100,
                   }
                }
            });
            
            
            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[1],
                QuestionNumber = 2,
                Caption = "یک  یا چند گزینه از سوال های زیر را وارد انتخاب کنید؟  تست 2",
                QuestionType = QuestionType.Checkbox,
                Choices = new List<Choice>()
                {
                   new Choice()
                   {
                       Caption = "گزینه یک",
                       Id = random.Next() %100,
                   },
                   new Choice()
                   {
                       Caption = "گزینه دو",
                       Id = random.Next() %100,
                   },
                   new Choice()
                   {
                       Caption = "گزینه سه",
                       Id = random.Next() %100,
                   }
                }
            });





            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[3],
                QuestionNumber = 3,
                QuestionType = QuestionType.SimpleText,
                Caption = "دلیل مراجعه شما به نمایندگی چه بوده؟",
                Choices = new List<Choice>()
                {
                new Choice()
                 {
                   Caption = "گزینه یک",
                   Id = random.Next() %100,
                 },
                }
            });


            
            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[4],
                QuestionNumber = 4,
                QuestionType = QuestionType.PhoneNumber,
                Caption = "شماره تلفن خود را وارد کنید؟",
                Choices = new List<Choice>()
                {
                new Choice()
                {
                    Caption = "",
                    Id = random.Next() %100,
                },
                }
            });



            return questionnaire;
        }
    }
}
