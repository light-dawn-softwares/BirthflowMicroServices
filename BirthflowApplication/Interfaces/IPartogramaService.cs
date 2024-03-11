using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Interfaces
{
	public interface IPartogramaService
	{
		IEnumerable<Partograma> GetPartogramas(Guid usuarioId);
		Partograma GetPartograma(string partogramaId);
        Partograma CreatePartograma(PartogramaDto partogramaDto);
    }
}