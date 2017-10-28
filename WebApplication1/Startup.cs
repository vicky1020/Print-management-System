using Microsoft.Owin;
using Owin;
using PrintManagement.Common.Interfaces;
using PrintManagement.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(PrintManagementApp.Startup))]
namespace PrintManagementApp
{
    public partial class Startup
    {
        private IRepository irepo;
        public static void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IRepository, Repository>();
     //       irepo = provider.GetService<IRepository>();
        }
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
    }
}
