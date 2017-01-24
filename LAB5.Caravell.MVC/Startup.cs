using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB5.Caravell.MVC.Startup))]
namespace LAB5.Caravell.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
