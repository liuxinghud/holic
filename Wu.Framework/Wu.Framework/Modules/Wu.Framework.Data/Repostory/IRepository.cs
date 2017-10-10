using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Data
{
   public interface IRepository
    {
        void Copy(object source, object target);
        void Delete(System.Collections.IEnumerable collection);
        void Delete(object obj);
        int DeleteById(object id);
        int DeleteById(System.Collections.IEnumerable identities);
        void Evict(object obj);
        object Load(object id);
        object Load(object id, object obj);
        object Refresh(object obj);
        object Merge(object entity);
        object GetIdentifier(object obj);
        void SetIdentifier(object obj, object id);

        void Save(System.Collections.IEnumerable collection);
        object Save(object obj);
        void SaveOrUpdate(object obj);
        void Update(System.Collections.IEnumerable collection);
        void Update(object obj);
        System.Type PersistentClass { get; }
    }


    public interface IRepository<T>: IRepository where T:class
    {

        void Copy(T source, T target);
        void Delete(IEnumerable<T> collection);
        void Delete(T obj);
        int Delete(Expression<Func<T, bool>> predicate);
        void Evict(T obj);
        void Flush();

        new T Load(object id);
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
