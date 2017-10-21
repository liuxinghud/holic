using NHibernate;
using NHibernate.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Data
{
     public class Repository<T> : IRepository<T> where T : class
    {
        private ISession session;
        private ISessionFactory sessionFactory;
        protected internal readonly NHibernate.Metadata.IClassMetadata ClassMetadata;
        static readonly Type persistentClass = typeof(T);
        readonly String entityName;
        readonly String queryAllString;
        readonly String identifierPropertyName;
        readonly DetachedQuery allQuery;
        readonly DetachedQuery allCountQuery;
        readonly DetachedQuery inIdentitiesQuery;

        public Repository(ISessionFactory sessionFactory, ISession session)
        {
            this.session = session ?? throw new ArgumentNullException("session", "未能获取 ISession的实例。");
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException("sessionFactory", "仓储层需要根据 ISessionFactory 获取Session，但未能获取 ISessionFactory 的实例。");
          
            ClassMetadata = sessionFactory.GetClassMetadata(persistentClass);
            identifierPropertyName = ClassMetadata.IdentifierPropertyName;
            entityName = ClassMetadata.EntityName;
            queryAllString = $"from {entityName}";
            allQuery = new DetachedQuery($"from {entityName}");

            allCountQuery = new DetachedQuery($"select count(*) from {entityName}");
            inIdentitiesQuery = new DetachedQuery($"from {entityName} where {identifierPropertyName} in (:identities)");
        }

        public void Copy(T source, T target)
        {
            var values = ClassMetadata.GetPropertyValues(source);
            ClassMetadata.SetPropertyValues(target, values);
        }

        public IQuery CreateQuery(string queryString)
        {
            return session.CreateQuery(queryString);
        }


        public void Delete(IEnumerable<T> collection)
        {
            if (collection == null) return;
            foreach (var item in collection)
            {
                session.Delete(entityName, item);
            }
        }

        public void Delete(T obj)
        {
            session.DeleteAsync(entityName, obj);
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            var collection = this.List(predicate);
            if (collection == null || collection.Count() == 0)
            {
                return 0;
            }
            if (collection.Count() == 1)
            {
                session.Delete(entityName, collection[0]);
                return 1;
            }
            for (int i = 0; i < collection.Count; i++)
            {
                session.Delete(entityName, collection[i]);
            }
            return collection.Count;
        }

        public void Delete(object obj)
        {
            session.DeleteAsync(entityName, obj);
        }

        public int DeleteById(object id)
        {
            return session.Delete($"from {entityName} where {ClassMetadata.IdentifierPropertyName}", id, ClassMetadata.IdentifierType);
        }



        public void Evict(T obj)
        {
            session.Evict(obj);
        }

        public void Flush()
        {
            session.FlushAsync();
        }

        public object GetIdentifier(T obj)
        {
            return session.GetIdentifier(obj);
        }

        public T Load(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            return session.Load(persistentClass, id) as T;
        }

        public T Load(object id, T obj)
        {
            if (id == null) throw new ArgumentNullException("id");
            session.Load(obj, id);
            return obj;
        }

        public T Merge(T entity)
        {
            return session.Merge<T>(entity);
        }

        public T Refresh(T obj)
        {
            session.Refresh(obj, LockMode.None);
            return obj;
        }

        public void Save(IEnumerable<T> collection)
        {
            if (collection == null) return;

            foreach (var item in collection)
            {
                session.SaveAsync(entityName, item);
            }
        }

        public object Save(T obj)
        {
            object x = session.SaveAsync(entityName, obj);
            return x;
        }


        public void SaveOrUpdate(T obj)
        {
            session.SaveOrUpdateAsync(entityName, obj);
        }

        public void SetIdentifier(T obj, object id)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            session.GetSessionImplementation().GetEntityPersister(entityName, obj).SetIdentifier(obj, id);
        }

        public void Update(IEnumerable<T> collection)
        {
            if (collection == null) return;
            foreach (var item in collection)
            {
                session.UpdateAsync(entityName, item);
            }
        }

        public void Update(T obj)
        {
            session.UpdateAsync(entityName, obj);
        }



        public async Task<int> CountAsync()
        {
            return await session.QueryOver<T>().RowCountAsync();
        }

        public int Count()
        {
            return session.QueryOver<T>().RowCount();
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return session.QueryOver<T>().Where(predicate).RowCount();
        }

        public bool Exists(object id)
        {
            return session.Get(entityName, id) != null;
        }
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.Count(predicate) >= 1;
        }
        public async Task<T> Get(object id)
        {
          return  await session.GetAsync(entityName, id) as T;
            
        }

        public IList<T> List()
        {
            return allQuery.GetExecutableQuery(session).List<T>();
        }
        public IList<T> List(Expression<Func<T, bool>> predicate)
        {
            return session.Query<T>().Where(predicate).ToList();
        }
        public IList<T> List(IEnumerable identities)
        {
            if (identities == null) return null;

            return inIdentitiesQuery.GetExecutableQuery(session)
                  .SetParameterList("identities", identities)
                  .List<T>();
        }
        public IList<T> List(string queryString, int firstResult, int maxResults)
        {
            var query = allQuery.GetExecutableQuery(session).SetFirstResult(firstResult).SetMaxResults(maxResults);
            return query.List<T>();
        }
        public IList<T> List(int firstResult, int maxResults)
        {
            return session.CreateQuery(queryAllString).SetFirstResult(firstResult).SetMaxResults(maxResults).List<T>();
            //   return this.allQuery.GetExecutableQuery(session).SetFirstResult(firstResult).SetMaxResults(maxResults).List<T>();
        }

        public IList<T> List(Expression<Func<T, bool>> predicate, int page, int pagesize)
        {
            return session.Query<T>().Where(predicate).Skip(page<0?0:(page-1)*pagesize).Take(pagesize).ToList();
        }

    }
}
