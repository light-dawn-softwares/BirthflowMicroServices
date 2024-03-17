using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface ITiempoTrabajoRepository
    {
        public TiempoTrabajo GetTiempoTrabajo(string partogramaId);

        public TiempoTrabajo UpdateTiempoTrabajo(TiempoTrabajo tiempoTrabajo);
    }
}
