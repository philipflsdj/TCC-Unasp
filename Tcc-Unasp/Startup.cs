using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tcc_Unasp.Startup))]
namespace Tcc_Unasp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
