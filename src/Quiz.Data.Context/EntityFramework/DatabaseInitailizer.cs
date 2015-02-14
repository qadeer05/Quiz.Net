using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;
using Quiz.Infrastructure;

namespace Quiz.Data.Context.EntityFramework
{
    public class DatabaseInitailizer : CreateDatabaseIfNotExists<QuizDbContext> 
    {
        protected override void Seed(QuizDbContext context)
        {
            var categories = new List<Category>
                {
                    new Category {Id = 1, Name = "English", DateCreated = DateTime.UtcNow.AddDays(-1)},
                    new Category {Id = 2, Name = "Math", DateCreated = DateTime.UtcNow.AddDays(-2)},
                    new Category {Id = 3, Name = "Quran", DateCreated = DateTime.UtcNow.AddDays(-3)}
                };

            categories.ForEach(s => context.CategorySet.AddOrUpdate(s));
            context.SaveChanges();
            var questions = new List<Question>
                {
                    new Question{CategoryId=1,QuestionString="Which is a proper noun?", Option1 = "Cow", Option2 = "John", Option3 = "Bus", Option4 = "Vertebrates", Answer = 2, DateCreated = DateTime.UtcNow},
                    new Question{CategoryId=1,QuestionString="Which among these is a verb?",Option1 = "King", Option2 = "Hill", Option3 = "Walk", Option4 = "Jacob", Answer = 3, DateCreated = DateTime.UtcNow},
                    new Question{CategoryId=1,QuestionString="Choose the adjective in the following sentence - This is a nice book.",Option1 = "Nice", Option2 = "Book", Option3 = "This", Option4 = "Is", Answer = 1, DateCreated = DateTime.UtcNow},
                    new Question{CategoryId=2,QuestionString="102 + 333 = ____",Option1 = "404", Option2 = "405", Option3 = "305", Option4 = "102333", Answer = 2, DateCreated = DateTime.UtcNow},
                    new Question{CategoryId=2,QuestionString="121/11 = ____",Option1 = "11", Option2 = "12", Option3 = "121", Option4 = "1", Answer = 1, DateCreated = DateTime.UtcNow},
                    new Question{CategoryId=3,QuestionString="Who among these is the son of prophet Ibrahim? ",Option1 = "Ibrahim", Option2 = "Ismail", Option3 = "Hud", Option4 = "Isa", Answer = 2, DateCreated = DateTime.UtcNow},
                    new Question{CategoryId=3,QuestionString="Which prophet was given the title Kalimullah (كليم الله)",Option1 = "Ibrahim", Option2 = "Isa", Option3 = "Muhammed", Option4 = "Musa", Answer = 4, DateCreated = DateTime.UtcNow}
                };
            questions.ForEach(q => context.QuestionSet.AddOrUpdate(q));
            context.SaveChanges();
        }

    }
}
