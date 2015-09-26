using Quiz.Data.Context.EntityFramework;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Infrastructure.Repositories
{
    public class QuestionBankRepository : RepositoryBase<Question>
    {
        public QuestionBankRepository(QuizDbContext context) : base(context) { }


        public IEnumerable<Question> GetQuestions(int categoryId, string sortOrder, string searchString)
        {
            var questions = Get();
            if (categoryId < 0)
                return new List<Question>();
            else
                questions = questions.Where(s => s.CategoryId.Equals(categoryId));

            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.QuestionString.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "category_desc":
                    questions = questions.OrderByDescending(s => s.Category.Name);
                    break;
                case "date":
                    questions = questions.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    questions = questions.OrderByDescending(s => s.DateCreated);
                    break;
                default:  
                    questions = questions.OrderBy(s => s.Category.Name);
                    break;
            }
            return questions;
        }
    }
}
