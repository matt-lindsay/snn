using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(snn.Startup))]
namespace snn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
