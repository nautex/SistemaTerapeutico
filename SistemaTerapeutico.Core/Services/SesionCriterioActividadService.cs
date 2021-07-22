using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class SesionCriterioActividadService : ISesionCriterioActividadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SesionCriterioActividadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad)
        {
            await _unitOfWork.SesionCriterioActividadRepository.Add(sesionCriterioActividad);
        }

        public void DeletePersonaDirecccionByIds(int idSesionCriterio, int idActividad)
        {
            _unitOfWork.SesionCriterioRepository.(idSesionCriterio, idActividad);
        }

        public void DeleteSesionesCriteriosActividadesByIdSesionCriterio(int idSesionCriterio)
        {
            throw new NotImplementedException();
        }

        public Task<SesionCriterioActividad> GetSesionCriterioActividadByIds(int idSesionCriterio, int idActividad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SesionCriterioActividad> GetSesionesCriteriosActividades()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SesionCriterioActividad>> GetSesionesCriteriosActividadesByidSesionCriterio(int idSesionCriterio)
        {
            throw new NotImplementedException();
        }

        public void UpdateSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad)
        {
            throw new NotImplementedException();
        }
    }
}
