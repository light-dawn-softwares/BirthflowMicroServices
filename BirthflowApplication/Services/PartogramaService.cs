using BirthflowMicroServices.Application.Interfaces;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Services
{
	public class PartogramaService : IPartogramaService
	{
		public Partograma GetPartograma(string partogramaId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Partograma> GetPartogramas(Guid usuarioId)
		{
			return new List<Partograma>() {
				new Partograma {
					PartogramaId = "1",
					UsuarioId = usuarioId,
					Nombre = "Nombre del Partograma",
					Expediente = "Expediente del Partograma",
					Fecha = DateTime.Now,
					IsDelete = false,
					CreateAt = DateTime.Now,
					UpdateAt = null,
				}
			};
		}
	}
}