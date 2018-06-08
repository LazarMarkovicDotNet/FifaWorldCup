using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FifaWorldCup.Startup))]
namespace FifaWorldCup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
