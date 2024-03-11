using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Application.Models
{
    public class PartogramaDto
    {
        public string? PartogramaId { get; set; } = null;
        public string UsuarioId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Expediente { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public TiempoTrabajoDto? TiempoTrabajo { get; set; }
    }
}
