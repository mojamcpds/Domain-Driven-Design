using System.Data.Entity;

namespace DMS.SharedKernel.Infrastructure.Data
{
    public class BaseDbContext<TContext> : DbContext
        where TContext : DbContext
        
    {
        static BaseDbContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseDbContext()
            : base("name=DmsContext")
        {
           
        }

       
    }
}
