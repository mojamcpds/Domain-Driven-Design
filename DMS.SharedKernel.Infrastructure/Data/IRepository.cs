using DMS.SharedKernel.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DMS.SharedKernel.Infrastructure.Data
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : Entity<TId>, IAggregateRoot
    {
        void Save(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Delete(Expression<Func<T, bool>> where);

    }
}
