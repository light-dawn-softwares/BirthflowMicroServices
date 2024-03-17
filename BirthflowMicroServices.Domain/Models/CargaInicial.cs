namespace BirthflowMicroServices.Domain.Models
{
    public class CargaInicial
    {
        public required IEnumerable<PosicionFetal> PosicionesFetales { get; set; }
        public required IEnumerable<PlanoHodge> PlanosHodge { get; set; }
    }
}