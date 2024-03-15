using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IDilatacionCervicalRepository
    {
        public IEnumerable<DilatacionCervical> GetDilatacionesCervicales(string partogramaId);

        public DilatacionCervical GetDilatacionCervical(string DilatacionCervicalId);

        public DilatacionCervical CreateDilatacionCervical(DilatacionCervical dilatacionCervical);

        public DilatacionCervical UpdateDilatacionCervical(DilatacionCervical dilatacionCervical);

        public void DeleteDilatacionCervical(string DilatacionCervicalId);
    }
}