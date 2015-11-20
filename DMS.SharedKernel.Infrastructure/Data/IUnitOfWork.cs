using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.SharedKernel.Infrastructure.Data
{
    public interface IUnitOfWork<TDbContext>:IDisposable 
        where TDbContext: IDbContext
    {
        int Commit();
        TDbContext Context { get; }
    }
}
