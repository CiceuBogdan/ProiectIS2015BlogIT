﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlogIT.Models;

namespace BlogIT.BusinessLogic.Interfaces
{
    public interface ICategoryBL
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task AddCategory(Category category);
        Task<SelectList> GetCategoriesForDropDownList();
    }
}
