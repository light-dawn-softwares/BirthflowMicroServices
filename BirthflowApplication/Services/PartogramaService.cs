using BirthflowMicroServices.Application.Interfaces;
using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BirthflowMicroServices.Application.Services
{
    public class PartogramaService : IPartogramaService
    {
        private readonly IPartogramaRepository _partogramaRepository;

        public PartogramaService(IPartogramaRepository partogramaRepository)
        {
            this._partogramaRepository = partogramaRepository;
        }

        public Partograma GetPartograma(string partogramaId)
        {
            try
            {
                return _partogramaRepository.GetPartograma(partogramaId); ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public IEnumerable<Partograma> GetPartogramas(Guid usuarioId)
        {
            try
            {
                return _partogramaRepository.GetPartogramas(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public Partograma CreatePartograma(PartogramaDto partogramaDto)
        {
            try
            {
                Guid usuarioId = Guid.Parse(partogramaDto.UsuarioId);

                Partograma partograma = new Partograma
                {
                    UsuarioId = usuarioId,
                    Nombre = partogramaDto.Nombre,
                    Expediente = partogramaDto.Expediente,
                    Fecha = partogramaDto.Fecha,

                };

                TiempoTrabajo tiempoTrabajo = new TiempoTrabajo
                {
                    PartogramaId = partogramaDto.PartogramaId!,
                    Paridad = partogramaDto.TiempoTrabajo!.Paridad,
                    Membranas = partogramaDto.TiempoTrabajo.Membranas,
                    Posicion = partogramaDto.TiempoTrabajo.Posicion,
                };

                return _partogramaRepository.CreatePartograma(partograma, tiempoTrabajo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}