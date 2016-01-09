using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogIT.BusinessLogic.Interfaces;
using BlogIT.Models;

namespace BlogIT.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryBL _iCategoryBL;

        public CategoryController(ICategoryBL iCategoryBL)
        {
            _iCategoryBL = iCategoryBL;
        }

        public async Task<ActionResult> Categories()
        {
            ViewBag.Categories = await _iCategoryBL.GetAllCategories();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _iCategoryBL.AddCategory(category);
            }
            else
            {
                ModelState.AddModelError("", "Name and Description are mandatory");
            }
            return RedirectToAction("Categories");
        }

        public ActionResult Category(string categoryId)
        {
            return RedirectToAction("Articles", "Article", new { categoryId = categoryId });
        }

       

    }
}
