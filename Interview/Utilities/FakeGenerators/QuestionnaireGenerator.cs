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

            //List<Choice> cities = _context.Cities.Select(x => new Choice() { Id = x.Id, Caption = x.Name }).ToList();
            //List<Choice> provinces = _context.Provinces.Select(x => new Choice() { Id = x.Id, Caption = x.Name }).ToList();


            //questionnaire.Questions.Add(
            //new Question()
            //{
            //    Id = questionIds[1],
            //    IsVisible = true,
            //    Caption = "استان محل سکونت را انتخاب کنید.",
            //    QuestionType = QuestionType.SingleSelectDropDown,
            //    Choices = provinces,

            //});

            //questionnaire.Questions.Add(
            //new Question()
            //{
            //    Id = questionIds[2],
            //    IsVisible = true,
            //    Caption = "شهر محل سکونت را انتخاب کنید.",
            //    QuestionType = QuestionType.SingleSelectDropDown,
            //    Choices = cities
            //}); 

            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[0],
                QuestionNumber = 1,
                IsVisible = true,
                Caption = "شهر محل سکونت را انتخاب کنید.",
                QuestionType = QuestionType.Checkbox,
                Choices = new List<Choice>()
                {
                   new Choice()
                   {
                       Caption = "گزینه یک",
                       Id = random.Next() %100,
                       DeleteQuestionIds= "",
                   },
                   new Choice()
                   {
                       Caption = "گزینه دو",
                       Id = random.Next() %100,
                       DeleteQuestionIds= "",
                   },
                   new Choice()
                   {
                       Caption = "حذف سوال دو و سه",
                       Id = random.Next() %100,
                       DeleteQuestionIds = string.Join(",", questionIds.Take(1..3)),
                   }
                }
            });
            
            
            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[1],
                QuestionNumber = 2,
                IsVisible = true,
                Caption = "استان محل سکونت را انتخاب کنید.",
                QuestionType = QuestionType.Checkbox,
                Choices = new List<Choice>()
                {
                   new Choice()
                   {
                       Caption = "گزینه یک",
                       Id = random.Next() %100,
                       DeleteQuestionIds= "",
                   },
                   new Choice()
                   {
                       Caption = "گزینه دو",
                       Id = random.Next() %100,
                       DeleteQuestionIds= "",
                   },
                   new Choice()
                   {
                       Caption = "حذف سوال چهار",
                       Id = random.Next() %100,
                       DeleteQuestionIds = questionIds[3].ToString(),
                   }
                }
            });







            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[2],
                QuestionNumber = 3,
                IsVisible = true,
                Caption = "پایتخت  ایران چه شهری است",
                QuestionType = QuestionType.Checkbox,
                Choices = new List<Choice>()
                {
                  new Choice() { Id = random.Next() % 100 , Caption = "تهران" },
                  new Choice() { Id = random.Next() % 100 , Caption = "حذف سوال پنج" , DeleteQuestionIds = questionIds[4].ToString()  }
                }
            });





            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[3],
                QuestionNumber = 4,
                IsVisible = true,
                QuestionType = QuestionType.SimpleText,
                Caption = "دلیل مراجعه شما به نمایندگی چه بوده؟",
                Choices = new List<Choice>()
                {
                new Choice()
                 {
                   Caption = "گزینه یک",
                   Id = random.Next() %100,
                   DeleteQuestionIds= "",
                 },
                }
            });


            
            questionnaire.Questions.Add(
            new Question()
            {
                Id = questionIds[4],
                QuestionNumber = 5,
                IsVisible = true,
                QuestionType = QuestionType.SimpleText,
                Caption = "دلیل مراجعه شما به نمایندگی چه بوده؟",
                Choices = new List<Choice>()
                {
                new Choice()
                {
                    Caption = "",
                    Id = random.Next() %100,
                    DeleteQuestionIds= "",
                },
                }
            });



            return questionnaire;
        }
    }
}
