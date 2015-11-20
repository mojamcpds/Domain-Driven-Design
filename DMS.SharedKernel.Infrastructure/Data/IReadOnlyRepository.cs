using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.SharedKernel.Infrastructure.Data
{
    public interface IReadOnlyRepository<T, TId> : IDisposable where T : Entity<TId>, IAggregateRoot
    {
        T GetById(TId id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        //Execute Stored Procedure
        IEnumerable<TClass> ExecWithStoreProcedure<TClass>(string query) where TClass:class ,new();
        void ExecuteWithStoreProcedure(string query, params object[] parameters);

    }
}
