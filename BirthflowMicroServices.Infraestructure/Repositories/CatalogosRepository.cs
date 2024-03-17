using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class CatalogosRepository : ICatalogosRepository
    {
        private readonly BirthFlowDbContext _context;

        public CatalogosRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CargaInicial GetCargaInicial()
        {
            try
            {
                IEnumerable<PosicionFetal> getPosicionesFetales = _context.PosicionesFetales.ToList();
                IEnumerable<PlanoHodge> getPlanosHodge = _context.PlanosHodge.ToList();

                return new CargaInicial
                {
                    PlanosHodge = getPlanosHodge,
                    PosicionesFetales = getPosicionesFetales,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<PosicionFetal> GetPosicionesFetales()
        {
            try
            {
                return _context.PosicionesFetales.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<PlanoHodge> GetPlanosHodge()
        {
            try
            {
                return _context.PlanosHodge.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}