using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Interfaces
{
    public interface IPartogramaService
    {
        public IEnumerable<Partograma> GetPartogramas(Guid usuarioId);

        public Partograma GetPartograma(string partogramaId);

        public Partograma CreatePartograma(PartogramaDto partogramaDto);

        public TiempoTrabajo GetTiempoTrabajo(string partogramaId);

        public TiempoTrabajo UpdateTiempoTrabajo(TiempoTrabajoDto tiempoTrabajoDto);

        public DilatacionCervical GetDilatacionCervical(string DilatacionCervicalId);

        public IEnumerable<DilatacionCervical> GetDilatacionesCervicales(string partogramaId);

        public DilatacionCervical CreateDilatacionCervical(DilatacionCervicalDto dilatacionCervicalDto);

        public DilatacionCervical UpdateDilatacionCervical(DilatacionCervicalDto dilatacionCervicalDto);

        public void DeleteDilatacionCervical(string dilatacionCervicalId);

        public IEnumerable<Vpp> GetVpps(string partogramaId);

        public Vpp GetVpp(string vppId);

        public Vpp CreateVpp(VppDto vppDto);

        public Vpp UpdateVpp(VppDto vppDto);

        public void DeleteVpp(string vppId);

        public IEnumerable<VigilanciaMedica> GetTablaVigilanciaMedica(string partogramaId);

        public VigilanciaMedica GetVigilancia(string vigilanciaMedicaId);

        public VigilanciaMedica CreateVigilanciaMedica(VigilanciaMedicaDto vigilanciaMedicaDto);

        public VigilanciaMedica UpdateVigilanciaMedica(VigilanciaMedicaDto vigilanciaMedicaDto);

        public void DeleteVigilanciaMedica(string vigilanciaMedicaId);

        public Observacion UpdateObservacion(ObservacionDto observacionDto);

        public void DeleteObservacion(string vigilanciaMedicaId);
    }
}