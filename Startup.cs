using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NosokFun.Models;




namespace NosokFun
{
    public class Startup
    {

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(option => 
            option.UseNpgsql(Configuration["Data:NosokFunProducts:Connectionstring"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            
            // app.UseRouting();

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "default",
                template: "{controller=Product}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);

        }
    }
}
