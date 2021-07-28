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
            _unitOfWork.SaveChanges();
        }

        public void DeleteSesionCriterioActividadByIds(int idSesion, int idObjetivoCriterio, int idActividad)
        {
            _unitOfWork.SesionCriterioActividadRepository.DeleteByThreeIds(idSesion, idObjetivoCriterio, idActividad);
            _unitOfWork.SaveChanges();
        }
        public void DeleteSesionesCriteriosActividadesByIdSesion(int idSesion)
        {
            _unitOfWork.SesionCriterioActividadRepository.DeletesById(idSesion);
            _unitOfWork.SaveChanges();
        }

        public async Task<SesionCriterioActividad> GetSesionCriterioActividadByIds(int idSesion, int idObjetivoCriterio, int idActividad)
        {
            return await _unitOfWork.SesionCriterioActividadRepository.GetByThreeIds(idSesion, idObjetivoCriterio, idActividad);
        }

        public IEnumerable<SesionCriterioActividad> GetSesionesCriteriosActividades()
        {
            return _unitOfWork.SesionCriterioActividadRepository.GetAll();
        }
        public async Task<IEnumerable<SesionCriterioActividad>> GetSesionesCriteriosActividadesByidSesion(int idSesion)
        {
            return await _unitOfWork.SesionCriterioActividadRepository.GetsById(idSesion);
        }

        public void UpdateSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad)
        {
            _unitOfWork.SesionCriterioActividadRepository.Update(sesionCriterioActividad);
            _unitOfWork.SaveChanges();
        }
    }
}
