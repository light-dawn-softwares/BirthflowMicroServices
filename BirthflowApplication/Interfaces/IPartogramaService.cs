﻿using BirthflowMicroServices.Application.Models;
using BirthflowMicroServices.Domain.Models;

namespace BirthflowMicroServices.Application.Interfaces
{
    public interface IPartogramaService
    {
        IEnumerable<Partograma> GetPartogramas(Guid usuarioId);

        Partograma GetPartograma(string partogramaId);

        Partograma CreatePartograma(PartogramaDto partogramaDto);

        public DilatacionCervical GetDilatacionCervical(string DilatacionCervicalId);

        public IEnumerable<DilatacionCervical> GetDilatacionesCervicales(string partogramaId);

        public DilatacionCervical CreateDilatacionCervical(DilatacionCervicalDto dilatacionCervicalDto);

        public DilatacionCervical UpdateDilatacionCervical(DilatacionCervicalDto dilatacionCervical);

        public void DeleteDilatacionCervical(string dilatacionCervicalId);

        public IEnumerable<Vpp> GetVpps(string partogramaId);

        public Vpp GetVpp(string vppId);

        public Vpp CreateVpp(VppDto vppDto);

        public Vpp UpdateVpp(VppDto vppDto);

        public void DeleteVpp(string vppId);
    }
}