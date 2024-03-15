using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Application.Interfaces
{
    public interface IUsuarioService
    {
        public Usuario CreateUsuario(UsuarioDto usuarioDto);
        public IEnumerable<Usuario> GetUsuarios();
    }
}
