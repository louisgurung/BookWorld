using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC1_BookWorld.Startup))]
namespace MVC1_BookWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
