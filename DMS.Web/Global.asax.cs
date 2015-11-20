using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DMS.Controllers;
using DMS.SharedKernel.Infrastructure.Configuration;
using DMS.SharedKernel.Infrastructure.EmailService;
using DMS.SharedKernel.Infrastructure.Logging;
using StructureMap;

namespace DMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrap.ConfigureDependencies();

            ControllerBuilder.Current.SetControllerFactory(new StructuremapControllerFactory());
           // Services.AutoMapperBootStrapper.ConfigureAutoMapper();


            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(ObjectFactory.GetInstance<IApplicationSettings>());

            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());

            EmailServiceFactory.InitializeEmailServiceFactory
                                  (ObjectFactory.GetInstance<IEmailService>());


            LoggingFactory.GetLogger().Log("Application Started");
        }
    }
}
