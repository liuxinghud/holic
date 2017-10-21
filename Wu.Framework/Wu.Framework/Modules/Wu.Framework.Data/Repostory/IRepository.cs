using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Data
{
   
   public  interface IRepository<T> where T:class
    {
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        bool Exists(object id);
        //object Get(object id);
        Task<T> Get(object id);
        IList<T> List();
        IList<T> List(System.Collections.IEnumerable identities);
        IList<T> List(int firstResult, int maxResults);
        IList<T> List(string queryString, int firstResult, int maxResults);
        IList<T> List(Expression<Func<T, bool>> predicate, int page, int pagesize);
        IList<T> List(Expression<Func<T, bool>> predicate);
        void Copy(T source, T target);
        IQuery CreateQuery(string queryString);
        void Delete(IEnumerable<T> collection);
        void Delete(T obj);
        int Delete(Expression<Func<T, bool>> predicate);
        void Delete(object obj);
        int DeleteById(object id);
        void Evict(T obj);
        void Flush();

         T Load(object id);
        T Load(object id, T obj);
        //bool HasLoad(T obj);
        T Refresh(T obj);
        T Merge(T entity);
        object GetIdentifier(T obj);
        void SetIdentifier(T obj, object id);
        void Save(IEnumerable<T> collection);
        object Save(T obj);
   
        void SaveOrUpdate(T obj);
        void Update(IEnumerable<T> collection);
        void Update(T obj);

    }
}
