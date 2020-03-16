using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDmoment3.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CDmoment3
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
            //Starta MVC
            services.AddControllersWithViews();

            //sessions
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                //Längd på session
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
            });

            //Middleware
            services.AddDbContext<CdDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CDdbString")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Gör att man kan använda statiska filer, exv CSS, JS osv
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Routing för MVC
                endpoints.MapControllerRoute(
                    name: "default",

                    //1. Välj vilken controller som ska användas. Är ingen vald använd "Home"
                    //2. Vilken undersida ska man till = vilken "action" ska utföras?
                    //3. Om man exv vill läsa in blogginlägg med specifikt ID
                    pattern: "{controller=CDdata}/{action=Index}/{Id?}"
                        );
            });
        }
    }
}
