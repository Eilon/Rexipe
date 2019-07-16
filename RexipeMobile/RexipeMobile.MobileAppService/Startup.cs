using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RexipeMobile.MobileAppService.Data;
using RexipeMobile.MobileAppService.GraphQL;
using RexipeMobile.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace RexipeMobile.MobileAppService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

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


            // For GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<RecipeSchema>();

            // Add GraphQL services and configure options
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = HostingEnvironment.IsDevelopment();
            })
                .AddGraphTypes(ServiceLifetime.Scoped);
            //.AddWebSockets() // Add required services for web socket support
            //.AddDataLoader(); // Add required services for DataLoader support
        }

        public void Configure(IApplicationBuilder app)
        {
            if (HostingEnvironment.IsDevelopment())
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

            // use HTTP middleware for ChatSchema at path /graphql
            app.UseGraphQL<RecipeSchema>("/graphql");

            // use graphiQL middleware at default url /graphiql
            app.UseGraphiQLServer(new GraphiQLOptions());

            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rexipe API V1");
            });
        }
    }
}
