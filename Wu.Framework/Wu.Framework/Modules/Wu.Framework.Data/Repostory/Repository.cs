using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Data
{
    public class Repository<T> : IRepository, IRepository<T> where T : class
    {
        public Type PersistentClass => throw new NotImplementedException();

        public void Copy(T source, T target)
        {
            throw new NotImplementedException();
        }

        public void Copy(object source, object target)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(IEnumerable identities)
        {
            throw new NotImplementedException();
        }

        public void Evict(T obj)
        {
            throw new NotImplementedException();
        }

        public void Evict(object obj)
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public object GetIdentifier(T obj)
        {
            throw new NotImplementedException();
        }

        public object GetIdentifier(object obj)
        {
            throw new NotImplementedException();
        }

        public T Load(object id)
        {
            throw new NotImplementedException();
        }

        public T Load(object id, T obj)
        {
            throw new NotImplementedException();
        }

        public object Load(object id, object obj)
        {
            throw new NotImplementedException();
        }

        public T Merge(T entity)
        {
            throw new NotImplementedException();
        }

        public object Merge(object entity)
        {
            throw new NotImplementedException();
        }

        public T Refresh(T obj)
        {
            throw new NotImplementedException();
        }

        public object Refresh(object obj)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public object Save(T obj)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable collection)
        {
            throw new NotImplementedException();
        }

        public object Save(object obj)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(T obj)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(object obj)
        {
            throw new NotImplementedException();
        }

        public void SetIdentifier(T obj, object id)
        {
            throw new NotImplementedException();
        }

        public void SetIdentifier(object obj, object id)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable collection)
        {
            throw new NotImplementedException();
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }

        object IRepository.Load(object id)
        {
            throw new NotImplementedException();
        }
    }
}
