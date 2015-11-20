using DMS.Books.Repositories;
using DMS.Books.Services.Implementations;
using DMS.Books.Services.Interfaces;
using DMS.SharedKernel.Infrastructure.Configuration;
using DMS.SharedKernel.Infrastructure.EmailService;
using DMS.SharedKernel.Infrastructure.Logging;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace DMS.Web
{
    public class Bootstrap
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }
        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {

                For<IBookDbContext>().Use<BookDbContext>();
               
               

                // Repositories Configure
                For<IBookRepository>().Use<BookRepository>();
                For<ICategoryRepository>().Use<CategoryRepository>();

                //Unit of Work configure
                For<IBookUnitOfWork>().Use<BookUnitOfWork>();

                // Services configure
                For<IBookFacade>().Use<BookFacade>();


                // Application Settings configure                 
                For<IApplicationSettings>().Use
                         <WebConfigApplicationSettings>();

                // Logger configure
                For<ILogger>().Use<Log4NetAdapter>();

                // Email Service configure                
                For<IEmailService>().Use<SMTPService>();


            }
        }

    }
}
