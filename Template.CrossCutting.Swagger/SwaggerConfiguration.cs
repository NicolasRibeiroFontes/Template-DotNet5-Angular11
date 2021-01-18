using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Template.CrossCutting.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {   
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Template",
                        Version = "v1",
                        Description = $".Net 5 + Angular 11",
                        Contact = new OpenApiContact
                        {
                            Name = "Nicolas Fontes",
                            Email = "nicolas.rfontes@gmail.com"
                        }
                    });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", Array.Empty<string>()}
                };

                // Set the comments path for the Swagger JSON and UI.
                //Console.WriteLine(Path.GetFileName("api-docs.xml"));
                //var _xmlPath = Path.Combine("./", "api-docs.xml");

                //options.IncludeXmlComments(_xmlPath);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    /* Documentation Route */
                    c.RoutePrefix = "api/documentation";

                    /* Access File with Documentation */
                    c.SwaggerEndpoint("../../swagger/v1/swagger.json", "API v1");
                });
        }
    }
}
