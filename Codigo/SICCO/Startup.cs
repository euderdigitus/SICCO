using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SICCO.Startup))]
namespace SICCO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
