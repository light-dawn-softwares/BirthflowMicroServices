using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IVigilanciaMedicaRepository
    {
        public IEnumerable<VigilanciaMedica> GetTablaVigilanciaMedica(string partogramaId);

        public VigilanciaMedica GetVigilancia(string vigilanciaMedicaId);

        public VigilanciaMedica CreateVigilanciaMedica(VigilanciaMedica vigilanciaMedica, Observacion observacion);

        public VigilanciaMedica UpdateVigilanciaMedica(VigilanciaMedica vigilanciaMedica);

        public void DeleteVigilanciaMedica(string vigilanciaMedicaId);

        public Observacion UpdateObservacion(Observacion observacion);

        public void DeleteObservacion(string vigilanciaMedicaId);
    }
}