namespace BirthflowMicroServices.Application.Models
{
    public class VigilanciaMedicaDto
    {
        public string? VigilanciaMedicaId { get; set; } = null;

        public string? PartogramaId { get; set; }

        public string PosicionMaterna { get; set; } = null!;

        public string PresionArterial { get; set; } = null!;

        public string PulsoMaterno { get; set; } = null!;

        public string FrecuenciaCardiacaFetal { get; set; } = null!;

        public string DuracionContracciones { get; set; } = null!;

        public string FrecuenciaContraciones { get; set; } = null!;

        public string DolorIntensidad { get; set; } = null!;

        public string DolorLocalizacion { get; set; } = null!;

        public DateTime Tiempo { get; set; }

        public ObservacionDto? observacion { get; set; } = null;
    }
}