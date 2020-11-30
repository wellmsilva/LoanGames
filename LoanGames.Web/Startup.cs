using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using LoanGames.Web.Configurations;
using Microsoft.AspNetCore.SpaServices;
using System.Reflection;

namespace LoanGames.Web
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
            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp/dist";
            });

            services.AddDatabaseConfiguration(Configuration);

            services.AddAutoMapperConfiguration();
            services.AddSwaggerConfiguration();
            services.AddJwtBearerConfiguration();
         
            services.AddDependencyInjectionConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DatabaseConfiguration.UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSpaStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // endpoints.MapToVueCliProxy(
                //  "{*path}",
                //  new SpaOptions { SourcePath = "clientApp" },
                //  npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                //  regex: "Compiled successfully"
                //    );
            });




            app.UseSwaggerSetup();


            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "clientapp";
                else
                    spa.Options.SourcePath = "clientapp/dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });


        }


    }
}
