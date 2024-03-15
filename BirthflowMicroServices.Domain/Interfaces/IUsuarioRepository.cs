using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario CreateUsuario(Usuario usuario);
        public IEnumerable<Usuario> GetUsuarios();
    }
}
