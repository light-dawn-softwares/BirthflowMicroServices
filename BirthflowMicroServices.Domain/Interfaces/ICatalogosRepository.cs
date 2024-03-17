using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface ICatalogosRepository
    {
        public CargaInicial GetCargaInicial();

        public IEnumerable<PosicionFetal> GetPosicionesFetales();

        public IEnumerable<PlanoHodge> GetPlanosHodge();
    }
}