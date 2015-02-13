using Quiz.Data.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Framework.Services
{
    public class QuestionBankService
    {
        public static IEnumerable<Question> GetQuestions(string category, string sortOrder, string searchString)
        {
            return null;
        }

        public static IQueryable<Category> GetCategories(string sortOrder, string searchString)
        {
            var uow = new QuestionBankUnitOfWork();
            var categories = uow.GetCategories(sortOrder, searchString);
            return categories;
        }
    }
}
