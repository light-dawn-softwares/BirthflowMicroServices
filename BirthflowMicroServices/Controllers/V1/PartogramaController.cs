using Asp.Versioning;
using BirthflowMicroServices.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BirthflowMicroServices.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]/[action]")]
	public class PartogramaController : Controller
	{

		private readonly BirthflowMicroServices.Application.Interfaces.IPartogramaService _service;
		public PartogramaController(BirthflowMicroServices.Application.Interfaces.IPartogramaService _service)
		{
			this._service = _service;
		}

		[HttpGet()]
		public IActionResult Get(string PartogramaId)
		{
			try
			{
				var result = _service.GetPartograma();
				return Ok(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
