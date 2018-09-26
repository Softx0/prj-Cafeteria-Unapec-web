using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prjCafeteriaUnapec.Startup))]
namespace prjCafeteriaUnapec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
