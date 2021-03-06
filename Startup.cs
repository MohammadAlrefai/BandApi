using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BandWebApi.Services;
using BandWebApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace BandWebApi
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
        {   /*
             * return json by defult
               services.AddControllers();
            */
            // return xml replace json 
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IBandAlbumRepository, BandAlbumRepository>();
            services.AddDbContext<BandAlbumContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefulteConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler(appBuilder=>  {
                    appBuilder.Run(async c=> {
                        c.Response.StatusCode=500;
                        await c.Response.WriteAsync("Something went horribly wrong, try again later ");
                    });
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
