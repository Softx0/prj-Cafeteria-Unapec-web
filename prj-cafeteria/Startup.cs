using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prj_cafeteria.Startup))]
namespace prj_cafeteria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
