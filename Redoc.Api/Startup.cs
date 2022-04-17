using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Redoc.Api.Utils;

namespace Redoc.Api
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
            services.AddControllers()
                .AddJsonOptions(options =>
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(options =>
            {

                options.SchemaFilter<EnumSchemaFilter>();
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Swagger with Redoc",
                        Version = "v1",
                        Description = "Swagger and Redoc DEMO.",
                        Contact = new OpenApiContact
                        {
                            Name = "Diego Barreto",
                            Email = "diego.almeidab@outlook.com"
                        },
                        
                        Extensions = new Dictionary<string, IOpenApiExtension>
                        {
                            {
                                "x-logo", new OpenApiObject
                                {
                                    {
                                        "url", new OpenApiString("https://raw.githubusercontent.com/Redocly/redoc/master/docs/images/redoc.png")
                                    }
          
                                }
                            }
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.EnableAnnotations();
      
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Documentation v1"));

            app.UseReDoc(options =>
            {
                options.DocumentTitle = "Swagger with Redoc";
                options.SpecUrl = "/swagger/v1/swagger.json";
                options.EnableUntrustedSpec();
                options.HideDownloadButton();
                options.ExpandResponses("200,201");

            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
