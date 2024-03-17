namespace BirthflowMicroServices.Application.Models
{
    public class VppDto
    {
        public string? VppId { get; set; } = null;

        public string? PartogramaId { get; set; }

        public int PlanoHodgeId { get; set; }

        public int PosicionFetalId { get; set; }

        public DateTime Tiempo { get; set; }
    }
}