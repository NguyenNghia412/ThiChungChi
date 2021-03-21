using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(test_zip.Startup))]
namespace test_zip
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
