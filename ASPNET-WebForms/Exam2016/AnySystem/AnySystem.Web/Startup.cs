using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnySystem.Web.Startup))]
namespace AnySystem.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
