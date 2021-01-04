using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakeboncoin.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace fakeboncoin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddTransient<IFavoris, FavorisCookieService>();
            //services.AddSingleton<IFavoris, FavorisSessionService>();
            //services.AddScoped<IFavoris, FavorisSessionService>();
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "/", new { controller="Annonce", action="Index"});
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "/search/{search}", new { controller = "Annonce", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "add",
                    pattern: "/add", new { controller = "Annonce", action = "Form" });
                endpoints.MapControllerRoute(
                    name: "detail",
                    pattern: "/detail/{id}", new { controller = "Annonce", action = "DetailAnnonce" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
            });
        }
    }
}
