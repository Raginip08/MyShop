using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories = new List<ProductCategory>();

        public CategoryRepository()
        {
            categories = (List<ProductCategory>)cache["categories"];
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory category)
        {
            categories.Add(category);
        }

        public void Update(ProductCategory category, string Id)
        {
            ProductCategory categoryToUpdate = categories.Find(p => p.Id == Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Category = category.Category;
            }
        }

        public void Delete(string Id)
        {
            ProductCategory categoryToDelete = categories.Find(p => p.Id == Id);
            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory categoryToFind = categories.Find(p => p.Id == Id);
            if (categoryToFind != null)
            {
                return categoryToFind;
            }
            else
            {
                return null;
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }
    }
}
