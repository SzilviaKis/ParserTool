using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParserTool.Startup))]
namespace ParserTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
