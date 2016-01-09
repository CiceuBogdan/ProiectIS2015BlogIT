using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogIT.BusinessLogic.Interfaces;
using BlogIT.DataAccess;
using BlogIT.Models;
using Microsoft.Practices.Unity;
using MongoDB.Bson;

namespace BlogIT.BusinessLogic
{
    public class CategoryBL : ICategoryBL
    {

        IDalEntity<Category> _iDalCategory;

        public CategoryBL([Dependency("Db")]IDalEntity<Category> iDalCategory)
        {
            _iDalCategory = iDalCategory;
        }



        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            IEnumerable<Category> categoriesList = await _iDalCategory.FindAsync(new BsonDocument());
        
            return categoriesList;
        }

        public async Task<SelectList> GetCategoriesForDropDownList()
        {
            SelectList result = new SelectList(await _iDalCategory.FindAsync(new BsonDocument()), "Id", "Name");
            return result;
        }

        public async Task AddCategory(Category category)
        {
            await _iDalCategory.InsertAsync(category);
        }
    }
}