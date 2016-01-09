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
    public class ArticleBL : IArticleBL
    {

        IDalEntity<Article> _iArticleDal;
        IDalEntity<Comment> _iCommentDal;
        IDalEntity<Category> _iCategoryDal;

        public ArticleBL([Dependency("Db")]IDalEntity<Article> iArticleDal, [Dependency("Db")]IDalEntity<Comment> iCommentDal, [Dependency("Db")]IDalEntity<Category> iCategoryDal)
        {
            _iArticleDal = iArticleDal;
            _iCommentDal = iCommentDal;
            _iCategoryDal = iCategoryDal;
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return null;
        }

        public async Task<IEnumerable<ArticleModel>> GetLatestArticles()
        {
            var articles= (await _iArticleDal.FindAsync(new BsonDocument())).OrderBy(x => x.Date).Take(5);
            List<ArticleModel> result = new List<ArticleModel>();
            foreach  (Article art in articles){
                Category category= await _iCategoryDal.GetByIdAsync(art.CategoryId);
                result.Add(new ArticleModel()
                            {
                                Id = art.Id,
                                CategoryId = art.CategoryId,
                                CategoryName = category.Name,
                                Title = art.Title,
                                Content = art.Content,
                                Date = art.Date,
                                Comments = new List<Comment>()
                            }
                );
            }

            return result;
        }

        public async Task AddArticle(Article article)
        {
            await _iArticleDal.InsertAsync(article);
        }

        public async Task<ArticleModel> GetArticleById(string articleId)
        {
            Article art = await _iArticleDal.GetByIdAsync(articleId);
            Category category = await _iCategoryDal.GetByIdAsync(art.CategoryId);
            IEnumerable<Comment> comms = (await _iCommentDal.FindAsync(new BsonDocument())).Where(comm => comm.ArticleId == articleId);

            return new ArticleModel()
            {
                Id = articleId,
                CategoryId = art.CategoryId,
                CategoryName = category.Name,
                Title = art.Title,
                Content = art.Content,
                Date = art.Date,
                Comments = comms.ToList()
            };
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesForCategory(string categoryId)
        {
            var articles = (await _iArticleDal.FindAsync(new BsonDocument())).Where(art => art.CategoryId == categoryId);
            List<ArticleModel> result = new List<ArticleModel>();
            foreach (Article art in articles)
            {
                Category category = await _iCategoryDal.GetByIdAsync(art.CategoryId);
                result.Add(new ArticleModel()
                {
                    Id = art.Id,
                    CategoryId = art.CategoryId,
                    CategoryName = category.Name,
                    Title = art.Title,
                    Content = art.Content,
                    Date = art.Date,
                    Comments = new List<Comment>()
                }
                );
            }

            return result;
        }
    }
}