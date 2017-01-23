using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mino.Startup))]
namespace Mino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
