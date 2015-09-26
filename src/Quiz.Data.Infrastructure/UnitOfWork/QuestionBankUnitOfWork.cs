using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;
using Quiz.Data.Infrastructure.Repositories;
using Quiz.Domain;
using Quiz.Infrastructure;
using Quiz.Infrastructure.Services;

namespace Quiz.Data.Infrastructure.UnitOfWork
{
    public class QuestionBankUnitOfWork: BaseUnitOfWork<QuizDbContext>
    {
        private readonly QuestionBankRepository _questionBankRepository;
        private readonly CategoryRepository _categoryRepository;

        public QuestionBankUnitOfWork()
        {
            Context = new QuizDbContext(Constants.DefaultConnectionString);
            _categoryRepository = new CategoryRepository(Context);
            _questionBankRepository = new QuestionBankRepository(Context);
        }

        public IEnumerable<Category> GetCategories(string sortOrder, string searchString)
        {
            return _categoryRepository.GetCategories(sortOrder, searchString);
        }

        public IEnumerable<Question> GetQuestions(int category, string sortOrder, string searchString)
        {
            return _questionBankRepository.GetQuestions(category, sortOrder, searchString);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }
    }
}
