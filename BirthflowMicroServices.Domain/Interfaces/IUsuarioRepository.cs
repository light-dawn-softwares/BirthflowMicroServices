using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario CreateUsuario(Usuario usuario);

        public IEnumerable<Usuario> GetUsuarios();
    }
}