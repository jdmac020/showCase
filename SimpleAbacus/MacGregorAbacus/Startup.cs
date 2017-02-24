using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MacGregorAbacus.Startup))]
namespace MacGregorAbacus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
