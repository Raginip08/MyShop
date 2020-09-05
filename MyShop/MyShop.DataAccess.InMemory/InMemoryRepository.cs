using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> where T: Base
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t, string Id)
        {
            T productToUpdate = items.Find(p => p.Id == Id);
            if (productToUpdate != null)
            {
                productToUpdate=t;
            }
        }

        public void Delete(string Id)
        {
            T productToDelete = items.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                items.Remove(productToDelete);
            }
        }

        public T Find(string Id)
        {
            T productToFind = items.Find(p => p.Id == Id);
            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception();  
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }
    }
}
