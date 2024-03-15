using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;
using NanoidDotNet;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class DilatacionCervicalRepository : IDilatacionCervicalRepository
    {
        private readonly BirthFlowDbContext _context;

        public DilatacionCervicalRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DilatacionCervical CreateDilatacionCervical(DilatacionCervical dilatacionCervical)
        {
            try
            {
                var id = Nanoid.Generate(size: 15);
                dilatacionCervical.DilatacionCervicalId = id;
                dilatacionCervical.CreateAt = DateTime.Now;
                dilatacionCervical.UpdateAt = null;
                dilatacionCervical.DeleteAt = null;
                _context.Add(dilatacionCervical);
                _context.SaveChanges();

                return _context.DilatacionesCervicales.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public void DeleteDilatacionCervical(string dilatacionCervicalId)
        {
            try
            {
                var searchElement = _context.DilatacionesCervicales.Find(dilatacionCervicalId);

                if (searchElement != null)
                {
                    searchElement.DeleteAt = DateTime.Now;
                    searchElement.IsDelete = true;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public DilatacionCervical GetDilatacionCervical(string DilatacionCervicalId)
        {
            try
            {
                return _context.DilatacionesCervicales.FirstOrDefault(p => p.DilatacionCervicalId == DilatacionCervicalId && !p.IsDelete)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public IEnumerable<DilatacionCervical> GetDilatacionesCervicales(string partogramaId)
        {
            try
            {
                return _context.DilatacionesCervicales.
                    Where(p => p.PartogramaId == partogramaId).
                    Where(p => p.IsDelete == false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public DilatacionCervical UpdateDilatacionCervical(DilatacionCervical dilatacionCervical)
        {
            var searchElement = _context.DilatacionesCervicales.Find(dilatacionCervical.DilatacionCervicalId);

            if (searchElement != null)
            {
                searchElement.Valor = dilatacionCervical.Valor;
                searchElement.Hora = dilatacionCervical.Hora;
                searchElement.RemOram = dilatacionCervical.RemOram;
                searchElement.UpdateAt = DateTime.Now;

                _context.SaveChanges();
            }

            return searchElement;
        }
    }
}