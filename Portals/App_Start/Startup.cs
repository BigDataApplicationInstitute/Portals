using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portals.Startup))]
namespace Portals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
