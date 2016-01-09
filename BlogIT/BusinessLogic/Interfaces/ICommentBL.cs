using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogIT.Models;

namespace BlogIT.BusinessLogic.Interfaces
{
    public interface ICommentBL
    {


        Task AddComment(Comment comment);
        Task<IEnumerable<Comment>> GetUnreadedPrivateComments();
        Task<IEnumerable<Comment>> GetCommentsForArticle(string articleId);
    }
}
