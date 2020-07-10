using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppMovies.Startup))]
namespace AppMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
