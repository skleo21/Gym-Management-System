using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myproject.Startup))]
namespace Myproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
