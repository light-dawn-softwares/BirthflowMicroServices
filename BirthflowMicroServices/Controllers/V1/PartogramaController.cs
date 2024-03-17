using Asp.Versioning;
using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Models;
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

        [HttpGet()]
        public IActionResult GetTiempoTrabajo(string partogramaId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetTiempoTrabajo(partogramaId);

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

        [HttpPatch()]
        public IActionResult UpdateTiempoTrabajo([FromBody] TiempoTrabajoDto tiempoTrabajoDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.UpdateTiempoTrabajo(tiempoTrabajoDto);

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
        public IActionResult GetDilatacionCervicales(string partogramaId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetDilatacionesCervicales(partogramaId);

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
        public IActionResult GetDilatacionCervical(string dilatacionCervicalId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetDilatacionCervical(dilatacionCervicalId);

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
        public IActionResult CreateDilatacionCervical([FromBody] DilatacionCervicalDto dilatacionCervicalDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.CreateDilatacionCervical(dilatacionCervicalDto);

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

        [HttpPatch()]
        public IActionResult UpdateDilatacionCervical([FromBody] DilatacionCervicalDto dilatacionCervicalDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.UpdateDilatacionCervical(dilatacionCervicalDto);

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

        [HttpDelete()]
        public IActionResult DeleteDilatacionCervical(string dilatacionCervical)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                _service.DeleteDilatacionCervical(dilatacionCervical);

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(new DilatacionCervical(), Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
                return Ok();
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
        public IActionResult GetVpps(string partogramaId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetVpps(partogramaId);

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
        public IActionResult GetVpp(string vvpId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.GetVpp(vvpId);

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
        public IActionResult CreateVppl([FromBody] VppDto vppDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.CreateVpp(vppDto);

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

        [HttpPatch()]
        public IActionResult UpdateVpp([FromBody] VppDto vppDto)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                var resultado = _service.UpdateVpp(vppDto);

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

        [HttpDelete()]
        public IActionResult DeleteVpp(string vppId)
        {
            StringBuilder stringBuilder = new();
            StringBuilder trace = stringBuilder;
            try
            {
                var nombreEvent = new StackTrace()!.GetFrame(0)?.GetMethod()?.Name;
                trace.AppendLine($"Servicio {nombreServicio} - Controller {nombreController} - Método: {nombreEvent}:");
                _logger.Log(LogLevel.Information, $"Inicio {nombreEvent}");
                //Servicio
                _service.DeleteVpp(vppId);

                trace.Append($"{nombreEvent} - Respuesta: " + JsonConvert.SerializeObject(new DilatacionCervical(), Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
                return Ok();
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