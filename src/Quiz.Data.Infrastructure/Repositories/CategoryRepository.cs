using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;
using Quiz.Domain;

namespace Quiz.Data.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(QuizDbContext context) : base(context) { }

        public IEnumerable<Category> GetCategories(string sortOrder, string searchString)
        {
            var categories = Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(s => s.Name);
                    break;
                case "date":
                    categories = categories.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    categories = categories.OrderByDescending(s => s.DateCreated);
                    break;
                default:  // Name ascending 
                    categories = categories.OrderBy(s => s.Name);
                    break;
            }
            return categories;
        }
    }
}
