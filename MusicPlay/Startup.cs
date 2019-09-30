using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicPlay.Startup))]
namespace MusicPlay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //hello world
        }
    }
}
