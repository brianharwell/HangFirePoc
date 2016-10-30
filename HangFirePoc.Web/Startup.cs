using System;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;

[assembly: OwinStartup(typeof(HangFirePoc.Web.Startup))]
namespace HangFirePoc.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var sqlServerStorageOptions = new SqlServerStorageOptions();

            sqlServerStorageOptions.QueuePollInterval = TimeSpan.FromSeconds(30);

            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=localhost;Initial Catalog=HangFirePoc;Integrated Security=SSPI;", sqlServerStorageOptions);

            app.UseHangfireDashboard();

            var backgroundJobServerOptions = new BackgroundJobServerOptions();
            
            backgroundJobServerOptions.WorkerCount = 1;

            app.UseHangfireServer(backgroundJobServerOptions);
        }
    }
}
