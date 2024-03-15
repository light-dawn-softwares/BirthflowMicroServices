using Asp.Versioning.ApiExplorer;
using BirthflowMicroServices.Extensions;
using BirthflowMicroServices.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace BirthflowMicroServices
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BirthFlowDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Birthflow"));
            });

            services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

            services
                .AddApiVersioning(options =>
                {
                    //indicating whether a default version is assumed when a client does
                    // does not provide an API version.
                    options.AssumeDefaultVersionWhenUnspecified = true;
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("newPolicy", app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Configurar el logger para escribir en la consola
            });

            services.AddResponseCompression();
            services.AddResponseCaching();

            // servicio para la generacion de PDFs
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();

                    // Itera sobre las descripciones de versiones y agrega un endpoint de Swagger para cada una
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        var url = $"/swagger/{description.GroupName}/swagger.json";
                        var name = description.GroupName.ToUpperInvariant();
                        options.SwaggerEndpoint(url, name);
                    }
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    // Configura las cabeceras de control de caché aquí
                    context.Context.Response.Headers["Cache-Control"] = "public,max-age=31536000";
                }
            });

            app.UseRouting();
            app.UseCors("newPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ErrorLoggingMiddleware>();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                // Add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();
            });

            DependencyConfigurationLoader.LoadDependencies(services, "dependencies.json");
        }
    }
}