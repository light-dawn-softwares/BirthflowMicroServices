using BirthflowMicroServices.Application.Interfaces;
using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Interfaces;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario CreateUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    NombreUsuario = usuarioDto.NombreUsuario,
                    Nombres = usuarioDto.Nombres,
                    Apellidos = usuarioDto.Apellidos,
                    Email = usuarioDto.Email,
                    PhoneNumber = usuarioDto.PhoneNumber,
                };
                return _usuarioRepository.CreateUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all Usuarios", ex);
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            try
            {
                return _usuarioRepository.GetUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all Usuarios", ex);
            }
        }
    }
}