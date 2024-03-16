using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Domain.Interfaces
{
    public interface IVppRepository
    {
        public IEnumerable<Vpp> GetVpps(string partogramaId);

        public Vpp GetVpp(string vppId);

        public Vpp CreateVpp(Vpp vpp);

        public Vpp UpdateVpp(Vpp vpp);

        public void DeleteVpp(string vppId);
    }
}