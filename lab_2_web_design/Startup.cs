using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab_2_web_design.Startup))]
namespace lab_2_web_design
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
