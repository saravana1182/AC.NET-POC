using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgileCourtPOC.Startup))]
namespace AgileCourtPOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
