using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PD_Medicine_2._0.Startup))]
namespace PD_Medicine_2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
