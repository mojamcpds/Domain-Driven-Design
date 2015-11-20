using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.SharedKernel.Infrastructure.Data
{
    public interface IDbContext: IDisposable
    {
        int SaveChanges();
        void SetModified<T, TId>(T entity) where T : Entity<TId>,
        IAggregateRoot ;
        void SetAdd<T, TId>(T entity) where T : Entity<TId>,
        IAggregateRoot;
        IDbSet<T> DbSet<T, TId>() where T : Entity<TId>, IAggregateRoot;
        IEnumerable<TClass> ExecuteQuery<TClass>(string query) where TClass : class, new();
        void ExecuteCommand(string query, params object[] parameters);

    }
}
