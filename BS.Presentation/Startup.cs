using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BS.Presentation.Startup))]
namespace BS.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
