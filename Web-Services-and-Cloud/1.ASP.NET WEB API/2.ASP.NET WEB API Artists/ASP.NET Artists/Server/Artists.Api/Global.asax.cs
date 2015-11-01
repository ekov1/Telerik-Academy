namespace Artists.Api
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
 