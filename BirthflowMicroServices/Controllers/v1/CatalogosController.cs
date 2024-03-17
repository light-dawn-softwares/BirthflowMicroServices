using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace BirthflowMicroServices.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CatalogosController : ControllerBase
    {
        private readonly BirthflowMicroServices.Application.Interfaces.ICatalogosService _service;
        private readonly ILogger<CatalogosController> _logger;

        private readonly string? nombreServicio;
        private readonly string? nombreController;

        public CatalogosController(Application.Interfaces.ICatalogosService _service, ILogger<CatalogosController> _logger)
        {
            this._service = _service;
            this._logger = _logger;
            nombreServicio = Assembly.GetExecutingAssembly().GetName().Name;
            nombreController = this.GetType().Name;
        }

        [HttpGet()]
        public IActionResult CargaInicial()
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetCargaInicial();

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
        public IActionResult GetPosicionesFetales()
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetPosicionesFetales();

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
        public IActionResult GetPlanosHodge()
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetPlanosHodge();

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