using Quiz.Data.Context.EntityFramework;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Infrastructure.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>
    {
        public QuestionRepository(QuizDbContext context) : base(context) { }


        public IQueryable<Question> GetQuestions(int categoryId, string sortOrder, string searchString)
        {
            var categories = Get();
            if(categoryId > 0)
                categories = categories.Where(q => q.CategoryId.Equals(categoryId));

            if (!String.IsNullOrEmpty(searchString))
                categories = categories.Where(s => s.QuestionString.Contains(searchString));
            
            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(s => s.QuestionString);
                    break;
                case "date":
                    categories = categories.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    categories = categories.OrderByDescending(s => s.DateCreated);
                    break;
                default:  // Name ascending 
                    categories = categories.OrderBy(s => s.QuestionString);
                    break;
            }
            return categories;
        }
    }
}
