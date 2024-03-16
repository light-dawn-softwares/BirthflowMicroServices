namespace BirthflowMicroServices.Application.Models
{
    public class DilatacionCervicalDto
    {
        public string? DilatacionCervicalId { get; set; } = null!;

        public string? PartogramaId { get; set; }

        public decimal Valor { get; set; }

        public DateTime Hora { get; set; }

        public bool RemOram { get; set; }
    }
}