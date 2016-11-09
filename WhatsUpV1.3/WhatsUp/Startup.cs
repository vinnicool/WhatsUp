using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhatsUp.Startup))]
namespace WhatsUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
