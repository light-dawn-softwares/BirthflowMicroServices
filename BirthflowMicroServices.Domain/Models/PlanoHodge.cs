namespace BirthflowMicroServices.Domain.Models;

    public partial class PlanoHodge
    {
        public string PlanoHodgeId { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Valor { get; set; } = null!;

        public DateTime CreateAt { get; set; }

        public virtual ICollection<Vpp> Vpps { get; set; } = new List<Vpp>();
    }