using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(API_project.Startup))]
namespace API_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
