namespace BirthflowMicroServices.Domain.Models
{
    public class CargaInicial
    {
        public IEnumerable<PosicionFetal> PosicionesFetales { get; set; }
        public IEnumerable<PlanoHodge> PlanosHodge { get; set; }
    }
}