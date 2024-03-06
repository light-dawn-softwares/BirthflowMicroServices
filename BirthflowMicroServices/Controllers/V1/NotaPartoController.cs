using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthflowMicroServices.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]/[action]")]
	public class NotaPartoController : Controller
	{
	}
}
