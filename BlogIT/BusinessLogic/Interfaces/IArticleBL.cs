using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogIT.Models;

namespace BlogIT.BusinessLogic.Interfaces
{
    public interface IArticleBL
    {

        Task AddArticle(Article article);
        Task<IEnumerable<ArticleModel>> GetLatestArticles();
        Task<ArticleModel> GetArticleById(string articleId);
        Task<IEnumerable<ArticleModel>> GetArticlesForCategory(string categoryId);
    }
}
