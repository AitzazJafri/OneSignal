using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneSignal.Web.Startup))]
namespace OneSignal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
