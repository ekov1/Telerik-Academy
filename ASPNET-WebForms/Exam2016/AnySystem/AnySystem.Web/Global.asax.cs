using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace AnySystem.Web
{
    using App_Start;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            DatabaseConfig.Initialize();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Response.Redirect("~/Errors/Error");
            }
        }
    }
}