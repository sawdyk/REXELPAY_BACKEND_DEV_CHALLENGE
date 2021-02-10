using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REXELPAY.Helpers.Utilities;
using Microsoft.OpenApi.Models;
using REXELPAY.Repository.Multiples.Repository.Interface;
using REXELPAY.Repository.Multiples.Repository;
using REXELPAY.Repository.Checkers.Repository.Interface;
using REXELPAY.Repository.Checkers.Repository;

namespace REXELPAY
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
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            //------------------------------SERVICES-------------------------------------------------------

            services.AddTransient<IMultiplesRepository, MultiplesRepository>();
            services.AddTransient<ICheckerRepository, CheckerRepository>();


            //------------------------------SWAGGER--------------------------------------------------------

            //Get the swagger value options
            var swaggerOpt = Configuration.GetSection("SwaggerOptions").Get<SwaggerOptions>();
            // Register Swagger  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = swaggerOpt.Title,
                    Version = swaggerOpt.Version
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger Middleware
            app.UseSwagger();
            // specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Multiples Of A Number");

            });

            //---------------- CORS --------------------------------

            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
