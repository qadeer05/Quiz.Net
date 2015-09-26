using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Quiz.Framework.Services;
using Quiz.Infrastructure;

namespace Quiz.Web.Controllers
{
    public class QuestionController : Controller
    {

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? categoryId, int? page)
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
            categoryId = categoryId ?? -1;
            var categoryName = (categoryId <= 0) ? "None" : QuestionBankService.GetCategoryById(categoryId.Value).Name;
            ViewBag.Title = string.Format("Questions in {0} category", categoryName);
            ViewBag.CategoryId = categoryId;
            var questions = QuestionBankService.GetQuestions(categoryId.Value, sortOrder, searchString);

            int pageNumber = (page ?? 1);
            return View(questions.ToPagedList(pageNumber, Constants.PageSize));
        }


        public ActionResult Create()
        {
            return null;
        }

        public ActionResult Edit()
        {
            return null;
        }

        public ActionResult Delete()
        {
            return null;
        }

    }
}
