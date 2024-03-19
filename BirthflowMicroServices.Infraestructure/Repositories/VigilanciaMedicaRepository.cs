using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;
using BirthflowMicroServices.Infraestructure.Helpers;
using Microsoft.EntityFrameworkCore;
using NanoidDotNet;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class VigilanciaMedicaRepository : IVigilanciaMedicaRepository
    {
        private readonly BirthFlowDbContext _context;

        public VigilanciaMedicaRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public VigilanciaMedica CreateVigilanciaMedica(VigilanciaMedica vigilanciaMedica, Observacion observacion)
        {
            try
            {
                var result = _context.VigilanciaMedicas.Where(vm => vm.PartogramaId == vigilanciaMedica.PartogramaId).ToList().Count;

                var id = Nanoid.Generate(size: 15);

                vigilanciaMedica.VigilanciaMedicaId = id;
                vigilanciaMedica.CreateAt = DateTime.Now;
                vigilanciaMedica.IsDelete = false;
                vigilanciaMedica.UpdateAt = null;
                vigilanciaMedica.DeleteAt = null;
                _context.Add(vigilanciaMedica);

                var header = Helper.GenerateHeader(result);

                observacion.VigilanciaMedicaId = id;
                observacion.Header = header;
                observacion.CreateAt = DateTime.Now;
                observacion.IsDelete = false;
                observacion.UpdateAt = null;
                observacion.DeleteAt = null;

                _context.Add(observacion);

                _context.SaveChanges();

                return _context.VigilanciaMedicas.Include(vm => vm.Observacione).
                    FirstOrDefault(vm => vm.VigilanciaMedicaId == id && !vm.IsDelete)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }

        public void DeleteObservacion(string vigilanciaMedicaId)
        {
            try
            {
                var result = _context.Observaciones.Find(vigilanciaMedicaId);

                if (result != null)
                {
                    result.DeleteAt = DateTime.Now;
                    result.IsDelete = true;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }

        public void DeleteVigilanciaMedica(string vigilanciaMedicaId)
        {
            try
            {
                var result = _context.VigilanciaMedicas.Find(vigilanciaMedicaId);

                if (result != null)
                {
                    result.DeleteAt = DateTime.Now;
                    result.IsDelete = true;

                    var observacionResult = _context.Observaciones.Find(vigilanciaMedicaId)!;

                    observacionResult.IsDelete = true;
                    observacionResult.DeleteAt = DateTime.Now;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }

        public IEnumerable<VigilanciaMedica> GetTablaVigilanciaMedica(string partogramaId)
        {
            try
            {
                return _context.VigilanciaMedicas.Include(vm => vm.Observacione).
                    Where(vm => vm.PartogramaId == partogramaId && !vm.IsDelete)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }

        public VigilanciaMedica GetVigilancia(string vigilanciaMedicaId)
        {
            try
            {
                return _context.VigilanciaMedicas.Include(vm => vm.Observacione).
                    FirstOrDefault(vm => vm.VigilanciaMedicaId == vigilanciaMedicaId && !vm.IsDelete)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }

        public Observacion UpdateObservacion(Observacion observacion)
        {
            try
            {
                var result = _context.Observaciones.Find(observacion.VigilanciaMedicaId);

                if (result != null)
                {
                    result.Descripcion = observacion.Descripcion;
                    result.UpdateAt = DateTime.Now;
                    _context.SaveChanges();
                }

                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }

        public VigilanciaMedica UpdateVigilanciaMedica(VigilanciaMedica vigilanciaMedica)
        {
            try
            {
                var result = _context.VigilanciaMedicas.Find(vigilanciaMedica.VigilanciaMedicaId);

                if (result != null)
                {
                    result.Tiempo = vigilanciaMedica.Tiempo;
                    result.FrecuenciaCardiacaFetal = vigilanciaMedica.FrecuenciaCardiacaFetal;
                    result.PosicionMaterna = vigilanciaMedica.PosicionMaterna;
                    result.FrecuenciaContraciones = vigilanciaMedica.FrecuenciaContraciones;
                    result.DuracionContracciones = vigilanciaMedica.DuracionContracciones;
                    result.PulsoMaterno = vigilanciaMedica.PulsoMaterno;
                    result.PresionArterial = vigilanciaMedica.PresionArterial;
                    result.DolorLocalizacion = vigilanciaMedica.DolorLocalizacion;
                    result.DolorIntensidad = vigilanciaMedica.DolorIntensidad;
                    result.UpdateAt = DateTime.Now;

                    _context.SaveChanges();
                }

                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting result", ex);
            }
        }
    }
}