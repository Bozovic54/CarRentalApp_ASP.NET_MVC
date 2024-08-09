using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RVASProject.Startup))]
namespace RVASProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
