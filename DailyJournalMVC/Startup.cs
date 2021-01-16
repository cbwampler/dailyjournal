using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailyJournalMVC.Startup))]
namespace DailyJournalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
