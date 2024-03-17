namespace BirthflowMicroServices.Domain.Models;

public partial class Vpp
{
    public string VppId { get; set; } = null!;

    public string? PartogramaId { get; set; }

    public int PlanoHodgeId { get; set; }

    public int PosicionFetalId { get; set; }

    public DateTime Tiempo { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Partograma? Partograma { get; set; }

    public virtual PlanoHodge PlanoHodge { get; set; } = null!;

    public virtual PosicionFetal PosicionFetal { get; set; } = null!;
}