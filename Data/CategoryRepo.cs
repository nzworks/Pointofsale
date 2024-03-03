using Microsoft.EntityFrameworkCore;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class CategoryRepo
    {
        private readonly PosDbContext _dbContext;

        public CategoryRepo( PosDbContext context)
        {
            _dbContext = context;
        }

        public void AddCategory(CategoryMdl category)
        {
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
        }

        public CategoryMdl GetCategoryById(int? categoryId)
        {
            return _dbContext.Category.Find(categoryId);
        }

        public IEnumerable<CategoryMdl> GetAllCategories()
        {
            return _dbContext.Category.ToList();
        }

        public void UpdateCategory(CategoryMdl category)
        {
            _dbContext.Category.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbContext.Category.Find(categoryId);
            if (category != null)
            {
                _dbContext.Category.Remove(category);
                _dbContext.SaveChanges();
            }
        }
    }
}
