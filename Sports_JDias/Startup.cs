using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sports_JDias.Startup))]
namespace Sports_JDias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
