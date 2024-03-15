using BirthflowMicroServices.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            var jsonObject = JObject.Parse(jsonConfig); // Parsea el JSON en un objeto JObject

            var dependenciasArray = jsonObject["DependencyConfiguration"]; // Obtiene el arreglo de dependencias

            if (dependenciasArray == null)
            {
                throw new JsonException("El JSON no contiene un arreglo 'DependencyConfiguration'.");
            }

            var dependencias = JsonConvert.DeserializeObject<List<DependencyConfiguration>>(dependenciasArray.ToString()); // Deserializa el arreglo en una lista de DependencyConfiguration

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