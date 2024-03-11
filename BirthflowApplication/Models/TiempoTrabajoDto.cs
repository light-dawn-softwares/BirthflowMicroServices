using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowMicroServices.Application.Models
{
    public class TiempoTrabajoDto
    {
        public string? PartogramaId { get; set; } = null;
        public string Posicion { get; set; } = null!;
        public string Paridad { get; set; } = null!;
        public string Membranas { get; set; } = null!;
    }
}
