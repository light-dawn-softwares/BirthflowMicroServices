using BirthflowMicroServices.Application.Interfaces;
using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Services
{
    public class CatalogosService : ICatalogosService
    {
        private readonly ICatalogosRepository _catalogosRepository;

        public CatalogosService(ICatalogosRepository _catalogosRepository)
        {
            this._catalogosRepository = _catalogosRepository;
        }

        public CargaInicial GetCargaInicial()
        {
            try
            {
                return _catalogosRepository.GetCargaInicial();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public IEnumerable<PlanoHodge> GetPlanosHodge()
        {
            try
            {
                return _catalogosRepository.GetPlanosHodge();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public IEnumerable<PosicionFetal> GetPosicionesFetales()
        {
            try
            {
                return _catalogosRepository.GetPosicionesFetales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}