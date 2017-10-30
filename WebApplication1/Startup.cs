using Owin;
using PrintManagement.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PrintManagementApp
{
    public partial class Startup
    {
        private IRepository irepo;
        public static void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
