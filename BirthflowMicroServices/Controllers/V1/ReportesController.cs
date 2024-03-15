using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BirthflowMicroServices.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ReportesController : Controller
    {
    }
}