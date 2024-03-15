using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Interfaces
{
    public interface IUsuarioService
    {
        public Usuario CreateUsuario(UsuarioDto usuarioDto);

        public IEnumerable<Usuario> GetUsuarios();
    }
}