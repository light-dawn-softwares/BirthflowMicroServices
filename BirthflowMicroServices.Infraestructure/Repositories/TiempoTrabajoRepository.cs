using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class TiempoTrabajoRepository : ITiempoTrabajoRepository
    {
        private readonly BirthFlowDbContext _context;

        public TiempoTrabajoRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TiempoTrabajo UpdateTiempoTrabajo(TiempoTrabajo tiempoTrabajo)
        {
            try
            {
                var result = _context.TiempoTrabajos.Find(tiempoTrabajo.PartogramaId);

                if (result != null)
                {
                    result.Paridad = tiempoTrabajo.Paridad;
                    result.Membranas = tiempoTrabajo.Membranas;
                    result.Posicion = tiempoTrabajo.Posicion;

                    result.UpdateAt = DateTime.Now;

                    _context.SaveChanges();
                }

                return _context.TiempoTrabajos.Find(tiempoTrabajo.PartogramaId)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public TiempoTrabajo GetTiempoTrabajo(string partogramaId)
        {
            try
            {
                return _context.TiempoTrabajos.Find(partogramaId)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}