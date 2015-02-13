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
    }
}
