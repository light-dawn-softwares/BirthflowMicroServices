namespace BirthflowMicroServices.Application.Models
{
    public class VppDto
    {
        public string? VppId { get; set; } = null;

        public string? PartogramaId { get; set; }

        public int PlanoHodgeId { get; set; } = null!;

        public int PosicionFetalId { get; set; } = null!;

        public DateTime Tiempo { get; set; }
    }
}