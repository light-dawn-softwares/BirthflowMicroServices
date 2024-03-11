using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;
using BirthflowMicroServices.Infraestructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class PartogramaRepository : IPartogramaRepository
    {
        private readonly BirthFlowDbContext _context;

        public PartogramaRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Partograma CreatePartograma(Partograma partograma, TiempoTrabajo tiempoTrabajo)
        {
            try
            {
                partograma.PartogramaId = PartogramaIdGenerator.CreateUniqueId(partograma.Nombre, DateTime.Now);
                partograma.IsDelete = false;
                partograma.UpdateAt = null;
                _context.Add(partograma);

                tiempoTrabajo.PartogramaId = tiempoTrabajo.PartogramaId;
                tiempoTrabajo.CreateAt = DateTime.Now;
                tiempoTrabajo.UpdateAt = null;
                _context.Add(tiempoTrabajo);

                PartogramaEstado partographState = new PartogramaEstado
                {
                    PartogramaId = partograma.PartogramaId,
                    Archivado = false,
                    Silenciado = false,
                    Permanente = false,

                    UpdateAt = null,
                };

                _context.Add(partographState);

                return GetPartograma(partogramaId: partograma.PartogramaId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Partograma GetPartograma(string partogramaId)
        {
            try
            {

                return _context.Partogramas.
                    Include(p => p.TiempoTrabajo).
                    Include(p => p.PartogramaEstado).
                    FirstOrDefault(p => p.PartogramaId == partogramaId && !p.IsDelete)!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Partograma> GetPartogramas(Guid usuarioId)
        {
            try
            {
                return _context.Partogramas.
                    Include(p => p.TiempoTrabajo).
                    Include(p => p.PartogramaEstado).
                    Where(p => p.UsuarioId == usuarioId).
                    Where(p => p.IsDelete == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
