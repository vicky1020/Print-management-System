using Microsoft.Owin;
using Owin;
using Common.Interfaces;
using Common.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        private IRepository irepo;
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
     //       irepo = provider.GetService<IRepository>();
        }
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
    }
}
