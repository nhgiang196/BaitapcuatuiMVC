using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaitapcuatuiMVC.Startup))]
namespace BaitapcuatuiMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
