using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeCare_PU.DAL;
using WeCare_PU.Models;

namespace WeCare_PU
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
            services.AddEntityFrameworkSqlServer().AddDbContext<WeCareBdContext>();
            services.AddMvc();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            /*  var connStr = Configuration["App::ConnectionStrings:DefaultConnection"];
              System.Console.WriteLine(connStr);
              services.AddDbContext<DbContext>(options => options.UseSqlServer(connStr));*/
            // var connection = @"Server=(LocalDB)\\MSSQLLocalDb;DataBase=WECARE_PU;Trusted_Connection=True;";
            /* services.AddDbContext<WeCareBdContext>(options => 
             options.UseSqlServer(Configuration.GetConnectionString("Server=(LocalDB)\\MSSQLLocalDb;DataBase=WECARE_PU;Trusted_Connection=True;")));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
