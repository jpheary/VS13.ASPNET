using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VS13.Startup))]
namespace VS13 {
    //
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
