using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImgHttpHandlerWebForms.Startup))]
namespace ImgHttpHandlerWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
