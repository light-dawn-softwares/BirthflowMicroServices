using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IPartogramaRepository
    {
        public Partograma CreatePartograma(Partograma partograma, TiempoTrabajo tiempoTrabajo);

        public IEnumerable<Partograma> GetPartogramas(Guid usuarioId);

        public Partograma GetPartograma(string partogramaId);
    }
}