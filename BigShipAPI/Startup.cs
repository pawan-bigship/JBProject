using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using JBProject.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Server.IISIntegration;
using JBProject.Data.Auth; 
using JBProject.Services.UserProfile;
using Microsoft.AspNetCore.Http;

namespace JBProject
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
            //Allow globally connections
            services.AddCors();
            //ends here
            //  services.AddAuthentication(IISDefaults.AuthenticationScheme);
            //ends here
            var connection = Configuration.GetConnectionString("BigShipDatabase");
         services.AddDbContextPool<BigShipContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            //adding Imapper
            services.AddAutoMapper(typeof(Startup));
            //very important to map repositroy
            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthRepository, AuthRepository>(); 
          services.AddScoped<lUserProfileService, UserProfileService>();
            //Ends Here 
            //Add Below code for applying authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
              .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
          ValidateIssuer = false,
          ValidateAudience = false
      };
  });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //enabling core globally
            if (env.IsDevelopment())
            {
                app.UseDirectoryBrowser();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseStaticFiles();
            //put this above   app.UseAuthorization(); always for applying authentication.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
