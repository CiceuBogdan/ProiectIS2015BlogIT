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
    public class ArticleController : Controller
    {
        IArticleBL _iArticleBL;
        ICategoryBL _iCategoryBL;

        public ArticleController(IArticleBL iArticleBL,ICategoryBL iCategoryBL)
        {
            _iArticleBL = iArticleBL;
            _iCategoryBL = iCategoryBL;
        }


        public async Task<ActionResult> AddArticle()
        {
            ViewBag.Categories = await _iCategoryBL.GetCategoriesForDropDownList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                await _iArticleBL.AddArticle(article);
                ViewBag.Articles = await _iArticleBL.GetLatestArticles();

                return View("~/Views/Home/Index.cshtml");
            }
            ViewBag.Categories = await _iCategoryBL.GetCategoriesForDropDownList();
            return View();
        }

        public async Task<ActionResult> Articles(string categoryId)
        {
            ViewBag.Articles = await _iArticleBL.GetArticlesForCategory(categoryId);

            return View();
        }

        public async Task<ActionResult> Article(string articleId)
        {
            ArticleModel model = await _iArticleBL.GetArticleById(articleId);
            return View(model);
        }



    }
}
