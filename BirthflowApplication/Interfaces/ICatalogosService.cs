using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Interfaces
{
    public interface ICatalogosService
    {
        public CargaInicial GetCargaInicial();

        public IEnumerable<PosicionFetal> GetPosicionesFetales();

        public IEnumerable<PlanoHodge> GetPlanosHodge();
    }
}