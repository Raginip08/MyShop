using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using MyShop.Core;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        ProductRepository()
        {
            products = (List<Product>)cache["produsts"];
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.Category = product.Category;
                productToUpdate.Image = product.Image;
            }
        }

        public void Delete(Product product)
        {
            Product productToDelete = products.Find(p => p.Id == product.Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
        }

        public Product Find(Product product)
        {
            Product productToFind = products.Find(p => p.Id == product.Id);
            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                return null;
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

    }
}
