using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RexipeMobile.MobileAppService.Data;
using RexipeMobile.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace RexipeMobile.MobileAppService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<RecipeRepository>();


            services.AddDbContext<RexipeDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RexipeDb"));
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Rexipe API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();

                // Emulators don't trust the HTTPS dev cert used by ASP.NET Core, so use HTTPS only in Staging/Production
                app.UseHttpsRedirection();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rexipe API V1");
            });
        }
    }
}
