using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;
using BirthflowMicroServices.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly BirthFlowDbContext _context;

        public UsuarioRepository(BirthFlowDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            try
            {
                usuario.UsuarioId = Guid.NewGuid();
                usuario.CreateAt = DateTime.Now;
                usuario.UpdateAt = DateTime.Now;
                usuario.IsDelete = false;
                usuario.DeleteAt = null;

                _context.Add(usuario);

                _context.SaveChanges();

                return _context.Usuarios.Find(keyValues: usuario.UsuarioId)!;
            }
            catch (Exception ex)
            { 

                throw new Exception("Error getting resulk", ex);
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            try
            {
                return _context.Usuarios.Where(Usuario => !Usuario.IsDelete).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all Usuarios", ex);
            }
        }
    }
}
