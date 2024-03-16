using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;
using NanoidDotNet;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class VppRepository : IVppRepository
    {
        private readonly BirthFlowDbContext _context;

        public VppRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Vpp CreateVpp(Vpp vpp)
        {
            try
            {
                var id = Nanoid.Generate(size: 15);
                vpp.VppId = id;

                vpp.CreateAt = DateTime.Now;
                vpp.UpdateAt = null;
                vpp.DeleteAt = null;
                _context.Add(vpp);
                _context.SaveChanges();

                return _context.Vpps.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public void DeleteVpp(string vppId)
        {
            try
            {
                var searchElement = _context.Vpps.Find(vppId);

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

        public Vpp GetVpp(string vppId)
        {
            try
            {
                return _context.Vpps.FirstOrDefault(p => p.VppId == vppId && !p.IsDelete)!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public IEnumerable<Vpp> GetVpps(string partogramaId)
        {
            try
            {
                return _context.Vpps.
                    Where(p => p.PartogramaId == partogramaId).
                    Where(p => p.IsDelete == false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting resulk", ex);
            }
        }

        public Vpp UpdateVpp(Vpp vpp)
        {
            var searchElement = _context.Vpps.Find(vpp.VppId);

            if (searchElement != null)
            {
                searchElement.PartogramaId = vpp.PartogramaId;
                searchElement.PlanoHodge = vpp.PlanoHodge;
                searchElement.Posicion = vpp.Posicion;
                searchElement.Tiempo = vpp.Tiempo;
                searchElement.UpdateAt = DateTime.Now;

                _context.SaveChanges();
            }

            return searchElement!;
        }
    }
}