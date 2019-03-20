﻿using Amazon.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 Configuration["Data:AmazonStoreDB:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => 
            options.UseSqlServer(
                Configuration["Data:AmazonStoreIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddTransient<IBookRepository, EFBookRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {

                routes.MapRoute(
               name: null,
               template: "{category}/Page{bookPage:int}",
               defaults: new { controller = "Book", action = "List" });

                routes.MapRoute(
                    name: null,
                    template: "Page{bookPage:int}",
                    defaults: new { controller = "Book", action = "List", bookPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Book", action = "List", bookPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Book", action = "List", bookPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
                //template: "{controller=Book}/{action=List}/{id?}");

            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
