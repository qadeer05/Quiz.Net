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
        public static IEnumerable<Question> GetQuestions(int categoryId, string sortOrder, string searchString)
        {
            var uow = new QuestionBankUnitOfWork();
            var categories = uow.GetQuestions(categoryId, sortOrder, searchString);
            return categories;
        }

        public static IEnumerable<Category> GetCategories(string sortOrder, string searchString)
        {
            var uow = new QuestionBankUnitOfWork();
            var categories = uow.GetCategories(sortOrder, searchString);
            return categories;
        }

        public static Category GetCategoryById(int categoryId)
        {
            var uow = new QuestionBankUnitOfWork();
            return uow.GetCategoryById(categoryId);
        }
    }
}
