using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICOnboardingP1.Startup))]
namespace ICOnboardingP1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
