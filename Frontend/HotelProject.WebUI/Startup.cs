using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace HotelProject.WebUI
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
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

            services.AddHttpClient();
            // bu k�sm� eklemeyi unutmu�tuk ondan dolay� �al��m�yordu 
            services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
            services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();
            // aradaki
            services.AddControllersWithViews().AddFluentValidation();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
                // proje seyiyesinde autohorize i�lemleri yapmak i�in yazd�k
            });
            // login path vericez �imdi de 
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; // http ye izin ver
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // 30 dk giri� yapmazsa logine at 
                options.LoginPath = "/Login/Index/"; // yolu d�zelttik art�k acount login de�il de indexe gidicek

            
            });
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
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Eror404","?code=(0)"); // 404 sayfas� i�in
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // proje seyiyesinde autohorize i�lemleri yapmak i�in yazd�k
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
