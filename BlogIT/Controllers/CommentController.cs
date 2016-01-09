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
    public class CommentController : Controller
    {
        ICommentBL _iCommentBL;

        public CommentController(ICommentBL iCommentBL)
        {
            _iCommentBL = iCommentBL;
        }


        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveMessage(Comment comment, string returnUrl = "~/Views/Comment/Contact.cshtml")
        {
            if (ModelState.IsValid)
            {
                await _iCommentBL.AddComment(comment);
            }
            else
            {
                ModelState.AddModelError("", "All fields are mandatory");
            }
            return View(returnUrl);
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(Comment comment)
        {
            await _iCommentBL.AddComment(comment);
            List<Comment> comms = (await _iCommentBL.GetCommentsForArticle(comment.ArticleId)).ToList();
            return PartialView("~/Views/Comment/Comments.cshtml", comms);
        }

        public async  Task<ActionResult> CheckPrivateMessages()
        {
            IEnumerable<Comment> model = await _iCommentBL.GetUnreadedPrivateComments();
            return View(model);
        }

    }
}
