using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lands8.Backend.Startup))]
namespace Lands8.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
