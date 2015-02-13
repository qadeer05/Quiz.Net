using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Quiz.Framework.Services;
using Quiz.Infrastructure;

namespace Quiz.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        public ActionResult QuestionsList(string sortOrder, string currentFilter, string searchString, string category, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var questions = QuestionBankService.GetQuestions(category, sortOrder, searchString);

            int pageNumber = (page ?? 1);
            return View(questions.ToPagedList(pageNumber, Constants.PageSize));
        }

        public ActionResult CategoryList(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var categories = QuestionBankService.GetCategories(sortOrder, searchString);

            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, Constants.PageSize));
        }
    }
}