using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projekbetol.Startup))]
namespace projekbetol
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
