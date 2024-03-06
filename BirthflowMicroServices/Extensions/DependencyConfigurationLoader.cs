using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System;
using BirthflowMicroServices.Models;

namespace BirthflowMicroServices.Extensions
{
	public static class DependencyConfigurationLoader
	{
		public static void LoadDependencies(IServiceCollection services, string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException($"El archivo de configuración de dependencias no se encontró en la ruta: {filePath}");
			}

			var jsonConfig = File.ReadAllText(filePath);
			var dependencias = JsonConvert.DeserializeObject<List<DependencyConfiguration>>(jsonConfig);

			foreach (var dependencia in dependencias!)
			{
				var tipoFrom = Type.GetType(dependencia.From);
				var tipoTo = Type.GetType(dependencia.To);

				switch (dependencia.DependencyType.ToLower())
				{
					case "scoped":
						services.AddScoped(tipoFrom!, tipoTo!);
						break;
					case "transient":
						services.AddTransient(tipoFrom!, tipoTo!);
						break;
					case "singleton":
						services.AddSingleton(tipoFrom!, tipoTo!);
						break;
					default:
						// Manejar error si el tipo de dependencia es incorrecto
						throw new ArgumentException($"Tipo de dependencia no válido: {dependencia.DependencyType}");
				}
			}
		}
	}
}
