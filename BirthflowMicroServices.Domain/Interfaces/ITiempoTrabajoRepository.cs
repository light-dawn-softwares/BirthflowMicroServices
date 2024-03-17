using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface ITiempoTrabajoRepository
    {
        public TiempoTrabajo GetTiempoTrabajo(string partogramaId);

        public TiempoTrabajo UpdateTiempoTrabajo(TiempoTrabajo tiempoTrabajo);
    }
}