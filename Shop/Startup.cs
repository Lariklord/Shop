using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interf;
//using Shop.Data.mocks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Rep;
using Microsoft.AspNetCore.Http;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot confstring;

       /* public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/

        [System.Obsolete]
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hosting)
        {
            confstring = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("appsettings1.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddTransient<IAllTovars, TovRep>();
            services.AddTransient<ITovarCat, CatRep>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<AddDb>(options=>options.UseSqlServer(confstring.GetConnectionString("DefaultConnection")));
            services.AddMemoryCache();
            services.AddSession();
            services.AddTransient<IAllOrders, OrderRep>();
  


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
           app.UseSession();
            app.UseMvcWithDefaultRoute();
             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Tov}/{action=List}");
             });
            
           /* app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Tov}/{action=List}");
                routes.MapRoute(name: "Filter", template: "Tov/{action}/{category?}", defaults: new { Controller = "Tov", action = "List" });

            });*/
            using (var scope = app.ApplicationServices.CreateScope())
            {
   
                AddDb content = scope.ServiceProvider.GetRequiredService<AddDb>();
                DBObj.Initial(content);

            }


        }
    }
}
