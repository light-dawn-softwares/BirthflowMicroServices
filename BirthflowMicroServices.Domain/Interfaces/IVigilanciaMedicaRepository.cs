using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
	public interface IVigilanciaMedicaRepository
	{
		public IEnumerable<VigilanciaMedica> GetTablaVigilanciaMedica(string partogramaId);

		public VigilanciaMedica GetVigilancia(string partogramaId);

		public VigilanciaMedica CreateVigilanciaMedica(VigilanciaMedica vigilanciaMedica);

		public VigilanciaMedica UpdateVigilanciaMedica(VigilanciaMedica vigilanciaMedica);

		public void DeleteVigilanciaMedica(string vigilanciaMedicaId);

		public Observacion UpdateObservacion(Observacion observacion);

		public void DeleteObservacion(string observacionId);
	}
}