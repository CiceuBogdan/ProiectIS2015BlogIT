using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogIT.Models;
using BlogIT.BusinessLogic.Interfaces;
using System.Threading.Tasks;

namespace BlogIT.Controllers
{
    public class HomeController : Controller
    {
        private IUserBL _iUserBL;
        private IArticleBL _iArticleBL;

        public HomeController(IUserBL iUserBL, IArticleBL iArticleBL)
        {
            _iUserBL = iUserBL;
            _iArticleBL = iArticleBL;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Articles = await _iArticleBL.GetLatestArticles();
            return View();
        }

        public ActionResult LoginWriter()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginWriter(Writer writer)
        {

            if (_iUserBL.Login(writer.password))
            {
                Session["isWriter"] = true;
                 ViewBag.Articles = await _iArticleBL.GetLatestArticles();
                return View("Index");
            }

            ModelState.AddModelError("password", "Password incorect");
            return View();
        }
    }
}
