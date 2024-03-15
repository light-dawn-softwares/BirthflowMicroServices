using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Application.Models
{
    public class UsuarioDto
    {
        public Guid? UsuarioId { get; set; } = null;
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Email { get; set; }
        public decimal? PhoneNumber { get; set; }
    }
}
