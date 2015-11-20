using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DMS.SharedKernel.Infrastructure.Data;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.Books.Repositories
{
    public abstract class BaseBookRepository<T,TId>:IRepository<T,TId>
        where T:Entity<TId>, IAggregateRoot
    {
        protected readonly IBookDbContext BookDbContext;
        private readonly IDbSet<T> _dbSet;
        protected BaseBookRepository(IBookUnitOfWork unitOfWork)
        {
            //For Actual
           // BookDbContext = unitOfWork.Context as BookDbContext;

            //For Test
            BookDbContext = unitOfWork.Context;

            if (BookDbContext == null)
                throw new NullReferenceException("Book DbContext is null");

            _dbSet = BookDbContext.DbSet<T, TId>();
        }

        public void Save(T obj)
        {
            _dbSet.Add(obj);
            BookDbContext.SetAdd<T, TId>(obj);
        }

        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            BookDbContext.SetModified<T, TId>(obj);
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var entities = _dbSet.Where(where);
            
            if(!entities.Any())
                return;

            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }
        }

        public T GetById(TId id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public IEnumerable<TClass> ExecWithStoreProcedure<TClass>(string query) where TClass : class, new()
        {
           return BookDbContext.ExecuteQuery<TClass>(query);
        }

        public void ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            BookDbContext.ExecuteCommand(query,parameters);
        }
        public void Dispose()
        {
            BookDbContext.Dispose();
        }

        
        
    }
}

