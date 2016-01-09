using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BlogIT.BusinessLogic.Interfaces;
using BlogIT.DataAccess;
using BlogIT.Models;
using Microsoft.Practices.Unity;
using MongoDB.Bson;





namespace BlogIT.BusinessLogic
{
    public class CommentBL : ICommentBL
    {



        IDalEntity<Comment> _iCommentDal;

        public CommentBL([Dependency("Db")]IDalEntity<Comment> iCommentDal)
        {
            _iCommentDal = iCommentDal;
        }

        public async Task AddComment(Comment comment)
        {
            await _iCommentDal.InsertAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetUnreadedPrivateComments()
        {
            return (await _iCommentDal.FindAsync(new BsonDocument())).Where(comm => comm.ArticleId == "0");
        }

        public async Task<IEnumerable<Comment>> GetCommentsForArticle(string articleId)
        {
            return (await _iCommentDal.FindAsync(new BsonDocument())).Where(comm => comm.ArticleId == articleId);
        }

    }
}