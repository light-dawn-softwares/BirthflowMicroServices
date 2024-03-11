using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IPartogramaRepository
    {
        public Partograma CreatePartograma(Partograma partograma, TiempoTrabajo tiempoTrabajo);

        public IEnumerable<Partograma> GetPartogramas(Guid usuarioId); 

        public Partograma GetPartograma(string partogramaId);
    }
}
