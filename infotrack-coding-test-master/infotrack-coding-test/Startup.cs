using infotrack_coding_test.services;
using infotrack_coding_test.services.interfaces;
using infotrack_coding_test.Services;
using infotrack_coding_test.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infotrack_coding_test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IParseSearchRequestService, ParseSearchRequestService>();
            services.AddScoped<IParseSearchResponseService, ParseSearchResponseService>();
            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<ISearchService, SearchService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Search}/{action=Search}/{id?}");
                
            });
        }
    }
}
