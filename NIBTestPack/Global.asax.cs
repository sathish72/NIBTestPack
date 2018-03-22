using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace NIBTestPack
{
    public class MvcApplication : HttpApplication
    {
        public static int GridPageSize = 1;
        public static int VersionNumber = (int)DateTime.Now.Ticks;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperWebConfiguration.Configure();
        }
    }
}
