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

        public void DeleteSesionCriterioActividadByIds(int idSesionCriterio, int idActividad)
        {
            _unitOfWork.SesionCriterioActividadRepository.DeleteByIds(idSesionCriterio, idActividad);
        }

        public void DeleteSesionesCriteriosActividadesByIdSesionCriterio(int idSesionCriterio)
        {
            _unitOfWork.SesionCriterioActividadRepository.DeletesById(idSesionCriterio);
        }

        public async Task<SesionCriterioActividad> GetSesionCriterioActividadByIds(int idSesionCriterio, int idActividad)
        {
            return await _unitOfWork.SesionCriterioActividadRepository.GetByIds(idSesionCriterio, idActividad);
        }

        public IEnumerable<SesionCriterioActividad> GetSesionesCriteriosActividades()
        {
            return _unitOfWork.SesionCriterioActividadRepository.GetAll();
        }
        public async Task<IEnumerable<SesionCriterioActividad>> GetSesionesCriteriosActividadesByidSesionCriterio(int idSesionCriterio)
        {
            return await _unitOfWork.SesionCriterioActividadRepository.GetsById(idSesionCriterio);
        }

        public void UpdateSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad)
        {
            _unitOfWork.SesionCriterioActividadRepository.Update(sesionCriterioActividad);
        }
    }
}
