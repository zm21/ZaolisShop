using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZaolisShop.Startup))]
namespace ZaolisShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
