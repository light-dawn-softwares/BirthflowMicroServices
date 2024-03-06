using BirthflowMicroServices.Extensions;
using BirthflowMicroServices.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
				options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings"));
			});

			services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
				});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthFlow.Api", Version = "Free", Description = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") });

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Por favor ingrese el token JWT como: 'Bearer {TOKEN}'.",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = "bearer"
				});
				
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
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "BirthflowMicroServices");
				c.RoutePrefix = string.Empty;
			});

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseCors("newPolicy");

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseMiddleware<ErrorLoggingMiddleware>();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}

		private void RegisterServices(IServiceCollection services)
		{
			DependencyConfigurationLoader.LoadDependencies(services, "dependencies.json");
		}
	}
}
