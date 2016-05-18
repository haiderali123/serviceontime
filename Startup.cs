using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Community2.Startup))]
namespace Community2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
