using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RizSoft.Blazor.Data;
using RizSoft.Blazor.Services;
using System;
using System.IO;

namespace RizSoft.Blazor.Server.UI
{
    public class Startup
    {

        private readonly IWebHostEnvironment WebHostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            WebHostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            if (Configuration["DbToUse"].ToLower() == "sqlite")
                 services.AddDbContext<AcmeDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("AcmeDbSqlite").Replace("$", WebHostingEnvironment.ContentRootPath)), ServiceLifetime.Transient);
            else
                services.AddDbContext<AcmeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AcmeDbSqlServer")), ServiceLifetime.Transient);


            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddScoped<BrowserService>();

            services.AddDevExpressBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
