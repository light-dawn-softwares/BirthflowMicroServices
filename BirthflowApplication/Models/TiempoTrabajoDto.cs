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