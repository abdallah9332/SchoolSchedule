using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_123.Startup))]
namespace _123
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
