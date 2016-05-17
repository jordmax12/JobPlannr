using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TBDplanner.Startup))]
namespace TBDplanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
