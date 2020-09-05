using MyShop.Core.Models;
using System.Linq;

namespace MyShop.DataAccess.InMemory
{
    public interface IInMemoryRepository<T> where T : Base
    {
        IQueryable<T> Collection();
        void commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t, string Id);
    }
}