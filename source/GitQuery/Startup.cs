using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitQuery.Startup))]
namespace GitQuery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
