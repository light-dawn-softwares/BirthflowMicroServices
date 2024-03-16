namespace BirthflowMicroServices.Application.Models
{
    public class VppDto
    {
        public string? VppId { get; set; } = null;

        public string? PartogramaId { get; set; }

        public string PlanoHodge { get; set; } = null!;

        public string Posicion { get; set; } = null!;

        public DateTime Tiempo { get; set; }
    }
}