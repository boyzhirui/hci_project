using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCI.Startup))]
namespace HCI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
