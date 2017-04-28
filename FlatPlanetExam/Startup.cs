using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlatPlanetExam.Startup))]
namespace FlatPlanetExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
