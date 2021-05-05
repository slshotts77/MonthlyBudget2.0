using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonthlyBudget.MVC.Startup))]
namespace MonthlyBudget.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
