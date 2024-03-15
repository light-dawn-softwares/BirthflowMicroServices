using Asp.Versioning;
using BirthflowMicroServices.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace BirthflowMicroServices.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class PartogramaController : ControllerBase
    {
        private readonly BirthflowMicroServices.Application.Interfaces.IPartogramaService _service;
        private readonly ILogger<PartogramaController> _logger;

        private readonly string? nombreServicio;
        private readonly string? nombreController;

        public PartogramaController(Application.Interfaces.IPartogramaService _service, ILogger<PartogramaController> _logger)
        {
            this._service = _service;
            this._logger = _logger;
            nombreServicio = Assembly.GetExecutingAssembly().GetName().Name;
            nombreController = this.GetType().Name;
        }

        [HttpGet()]
        public IActionResult GetPartogramas(Guid userId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetPartogramas(userId);

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(resultado, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                trace.AppendLine($"Ocurrió un error no controlado {ex.Message}");
                throw new Exception(ex.Message);
            }
            finally
            {
                Console.WriteLine(trace);
                trace.Clear();
            }
        }

        [HttpGet()]
        public IActionResult GetPartograma(string partogramaId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetPartograma(partogramaId);

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(resultado, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                trace.AppendLine($"Ocurrió un error no controlado {ex.Message}");
                throw new Exception(ex.Message);
            }
            finally
            {
                Console.WriteLine(trace);
                trace.Clear();
            }
        }

        [HttpPost()]
        public IActionResult CreatePartograma([FromBody] PartogramaDto partogramaDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.CreatePartograma(partogramaDto);

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(resultado, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                trace.AppendLine($"Ocurrió un error no controlado {ex.Message}");
                throw new Exception(ex.Message);
            }
            finally
            {
                Console.WriteLine(trace);
                trace.Clear();
            }
        }
    }
}