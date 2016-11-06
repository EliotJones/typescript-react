using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using typescript_react_server.Settings;

namespace typescript_react_server
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddOptions();

            services.Configure<SiteSettings>(Configuration.GetSection("SiteOptions"));
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions());

            app.UseMvc(routes =>
            {
                routes.MapRoute("default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
