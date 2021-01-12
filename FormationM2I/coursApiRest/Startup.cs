using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using coursApiRest.Models;
using coursApiRest.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace coursApiRest
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
            services.AddDbContext<DataDbContext>((options) => {
                options.UseSqlServer(Configuration.GetConnectionString("default"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                        //builder.WithOrigins("ip1", "ip2").WithMethods("GET", "POST");
                    }
                    );

                options.AddPolicy(
                    "Admin",
                    builder =>
                    {
                        //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                        builder.WithOrigins("ip1", "ip2").AllowAnyMethod();
                    }
                    );

            });
            services.AddTransient<IProduct, ProductService>();
            services.AddTransient<IDAO<Product>, ProductDAOService>();
            services.AddTransient<IUpload, UploadService>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration.GetValue<string>("jwt:issuer"),
                    ValidAudience = Configuration.GetValue<string>("jwt:audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("jwt:key")))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("connect", builder =>
                {
                    builder.Requirements.Add(new ConnectRequirement());
                });
            });
            services.AddTransient<IAuthorizationHandler, CustomAuthorizationHandler>();
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
