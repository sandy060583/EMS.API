using System.Collections.Generic;

namespace EMS.Api.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
