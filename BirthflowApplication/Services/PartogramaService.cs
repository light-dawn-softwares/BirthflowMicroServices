using BirthflowMicroServices.Application.Interfaces;
using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Services
{
    public class PartogramaService : IPartogramaService
    {
        private readonly IPartogramaRepository _partogramaRepository;
        private readonly IDilatacionCervicalRepository _dilatacionCervicalRepository;
        private readonly IVppRepository _vppRepository;
        private readonly ITiempoTrabajoRepository _tiempoTrabajoRepository;

        public PartogramaService(IPartogramaRepository partogramaRepository, IDilatacionCervicalRepository dilatacionCervicalRepository, IVppRepository vppRepository, ITiempoTrabajoRepository tiempoTrabajoRepository)
        {
            this._partogramaRepository = partogramaRepository;
            this._dilatacionCervicalRepository = dilatacionCervicalRepository;
            this._vppRepository = vppRepository;
            _tiempoTrabajoRepository = tiempoTrabajoRepository;
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

        public DilatacionCervical GetDilatacionCervical(string DilatacionCervicalId)
        {
            try
            {
                return _dilatacionCervicalRepository.GetDilatacionCervical(DilatacionCervicalId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public IEnumerable<DilatacionCervical> GetDilatacionesCervicales(string partogramaId)
        {
            try
            {
                return _dilatacionCervicalRepository.GetDilatacionesCervicales(partogramaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public DilatacionCervical CreateDilatacionCervical(DilatacionCervicalDto dilatacionCervicalDto)
        {
            try
            {
                var dilatacion = new DilatacionCervical
                {
                    PartogramaId = dilatacionCervicalDto.PartogramaId,
                    Hora = dilatacionCervicalDto.Hora,
                    Valor = dilatacionCervicalDto.Valor,
                };

                return _dilatacionCervicalRepository.CreateDilatacionCervical(dilatacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public DilatacionCervical UpdateDilatacionCervical(DilatacionCervicalDto dilatacionCervicalDto)
        {
            try
            {
                var dilatacion = new DilatacionCervical
                {
                    DilatacionCervicalId = dilatacionCervicalDto.DilatacionCervicalId!,
                    PartogramaId = dilatacionCervicalDto.PartogramaId,
                    Hora = dilatacionCervicalDto.Hora,
                    Valor = dilatacionCervicalDto.Valor,
                };

                return _dilatacionCervicalRepository.UpdateDilatacionCervical(dilatacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public void DeleteDilatacionCervical(string DilatacionCervicalId)
        {
            try
            {
                _dilatacionCervicalRepository.DeleteDilatacionCervical(DilatacionCervicalId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public IEnumerable<Vpp> GetVpps(string partogramaId)
        {
            try
            {
                return _vppRepository.GetVpps(partogramaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public Vpp GetVpp(string vppId)
        {
            try
            {
                if (vppId == null)
                    throw new Exception();

                return _vppRepository.GetVpp(vppId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public Vpp CreateVpp(VppDto vppDto)
        {
            var vpp = new Vpp
            {
                PartogramaId = vppDto.PartogramaId,
                PlanoHodgeId = vppDto.PlanoHodgeId,
                PosicionFetalId = vppDto.PosicionFetalId,
                Tiempo = vppDto.Tiempo,
            };

            return _vppRepository.CreateVpp(vpp);
        }

        public Vpp UpdateVpp(VppDto vppDto)
        {
            try
            {
                if (vppDto.VppId == null)
                    throw new Exception();

                var vpp = new Vpp
                {
                    VppId = vppDto.VppId!,
                    PartogramaId = vppDto.PartogramaId,
                    PlanoHodgeId = vppDto.PlanoHodgeId,
                    PosicionFetalId = vppDto.PosicionFetalId,
                    Tiempo = vppDto.Tiempo,
                };

                return _vppRepository.UpdateVpp(vpp);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public void DeleteVpp(string vppId)
        {
            try
            {
                _vppRepository.DeleteVpp(vppId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public TiempoTrabajo GetTiempoTrabajo(string partogramaId)
        {
            try
            {
                return _tiempoTrabajoRepository.GetTiempoTrabajo(partogramaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public TiempoTrabajo UpdateTiempoTrabajo(TiempoTrabajoDto tiempoTrabajoDto)
        {
            try
            {
                var tiempoTrabajo = new TiempoTrabajo()
                {
                    PartogramaId = tiempoTrabajoDto.PartogramaId,
                    Membranas = tiempoTrabajoDto.Membranas,
                    Posicion = tiempoTrabajoDto.Posicion,
                    Paridad = tiempoTrabajoDto.Paridad,
                };

                return _tiempoTrabajoRepository.UpdateTiempoTrabajo(tiempoTrabajo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}