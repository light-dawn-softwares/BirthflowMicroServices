using Asp.Versioning;
using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Controllers.V1;
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
    public class UsuarioController : Controller
    {

        private readonly BirthflowMicroServices.Application.Interfaces.IUsuarioService _service;
        private readonly ILogger<UsuarioController> _logger;

        private readonly string? nombreServicio;
        private readonly string? nombreController;

        public UsuarioController(Application.Interfaces.IUsuarioService _service, ILogger<UsuarioController> _logger)
        {
            this._service = _service;
            this._logger = _logger;
            nombreServicio = Assembly.GetExecutingAssembly().GetName().Name;
            nombreController = this.GetType().Name;
        }


        [HttpGet()]
        public IActionResult GetPartogramas()
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetUsuarios();

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(resultado));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                trace.AppendLine($"Ocurrió un error no controlado {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpPost()]
        public IActionResult CreateUsuario([FromBody] UsuarioDto usuarioDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.CreateUsuario(usuarioDto);

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(resultado));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                trace.AppendLine($"Ocurrió un error no controlado {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
