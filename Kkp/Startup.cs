using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kkp.Startup))]
namespace Kkp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
